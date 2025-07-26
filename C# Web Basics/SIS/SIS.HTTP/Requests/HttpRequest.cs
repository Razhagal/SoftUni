using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Headers;

using System.Net;

namespace SIS.HTTP.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));

            this.FormData = new Dictionary<string, ISet<string>>();
            this.QueryData = new Dictionary<string, ISet<string>>();
            this.Headers = new HttpHeaderCollection();

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; } = null!;

        public string Url { get; private set; } = null!;

        public Dictionary<string, ISet<string>> FormData { get; }

        public Dictionary<string, ISet<string>> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString.Split(GlobalConstants.HttpNewLine, StringSplitOptions.None);
            string[] requestLine = splitRequestContent[0].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            this.ParseCookies();

            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            this.RequestMethod = Enum.Parse<HttpRequestMethod>(requestLine[0], true);
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            this.Url = WebUtility.UrlDecode(requestLine[1]);
        }

        // To Do: Check if Url is valid
        private void ParseRequestPath()
        {
            this.Path = this.Url.Split('?', StringSplitOptions.RemoveEmptyEntries)[0];
        }

        private void ParseHeaders(string[] requestContent)
        {
            foreach (var row in requestContent)
            {
                if (row == GlobalConstants.HttpNewLine)
                {
                    break;
                }

                string[] headerData = row.Split(':', StringSplitOptions.RemoveEmptyEntries);
                if (headerData.Length != 2)
                {
                    throw new BadRequestException();
                }

                HttpHeader header = new HttpHeader(headerData[0], headerData[1]);
                this.Headers.AddHeader(header);
            }

            if (!this.Headers.ContainsHeader("Host"))
            {
                throw new BadRequestException();
            }
        }

        private void ParseCookies()
        {
            //To Do...
        }

        private void ParseRequestParameters(string formData)
        {
            ParseQueryParameters();
            ParseFormDataParameters(formData);
        }

        private void ParseQueryParameters()
        {
            if (this.HasQueryString())
            {
                string queryString = this.Url.Split('?', StringSplitOptions.RemoveEmptyEntries)[1];
                string[] queryParams = queryString
                    .Split('#', StringSplitOptions.RemoveEmptyEntries)[0]
                    .Split('&', StringSplitOptions.RemoveEmptyEntries);

                if (!IsValidRequestQueryString(queryString, queryParams))
                {
                    throw new BadRequestException();
                }

                foreach (var queryParam in queryParams)
                {
                    string[] splitQueryParam = queryParam.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string queryParamKey = splitQueryParam[0];
                    string queryParamValue = splitQueryParam[1];

                    if (!this.QueryData.ContainsKey(queryParamKey))
                    {
                        this.QueryData.Add(queryParamKey, new HashSet<string>());
                    }

                    this.QueryData[queryParamKey].Add(WebUtility.UrlDecode(queryParamValue));
                }
            }
        }

        private void ParseFormDataParameters(string formData)
        {
            if (string.IsNullOrEmpty(formData))
            {
                return;
            }

            string[] formParams = formData.Split('&', StringSplitOptions.RemoveEmptyEntries);
            foreach (var param in formParams)
            {
                string[] splitFormParams = param.Split('=', StringSplitOptions.RemoveEmptyEntries);
                string formParamKey = splitFormParams[0];
                string formParamValue = splitFormParams[1];

                if (!this.FormData.ContainsKey(formParamKey))
                {
                    this.FormData.Add(formParamKey, new HashSet<string>());
                }

                this.FormData[formParamKey].Add(WebUtility.UrlDecode(formParamValue));
            }
        }

        private bool IsValidRequestLine(string[] requestLine)
        {
            return requestLine.Length == 3 &&
                (requestLine[2] == GlobalConstants.HttpOneProtocolFragment || requestLine[2] == GlobalConstants.HttpTwoProtocolFragment);
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParams)
        {
            return !string.IsNullOrEmpty(queryString) && queryParams.Length > 0;
        }

        private bool HasQueryString()
        {
            return this.Url.Split('?', StringSplitOptions.RemoveEmptyEntries).Length > 1;
        }
    }
}