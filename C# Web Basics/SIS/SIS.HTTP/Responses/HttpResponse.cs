using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Headers;

using System.Text;

namespace SIS.HTTP.Responses
{
    public class HttpResponse : IHttpResponse
    {
        public HttpResponse()
        {
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
        }

        public HttpResponse(HttpResponseStatusCode statusCode)
            : this()
        {
            CoreValidator.ThrowIfNull(statusCode, nameof(statusCode));
            this.StatusCode = statusCode;
        }

        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; }

        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
        {
            CoreValidator.ThrowIfNull(header, nameof(header));
            this.Headers.AddHeader(header);
        }

        public byte[] GetBytes()
        {
            byte[] baseResponseWithoutBody = Encoding.UTF8.GetBytes(this.ToString());
            byte[] fullResponseWithBody = new byte[baseResponseWithoutBody.Length + this.Content.Length];

            for (int i = 0; i < baseResponseWithoutBody.Length; i++)
            {
                fullResponseWithBody[i] = baseResponseWithoutBody[i];
            }

            for (int i = 0; i < this.Content.Length; i++)
            {
                fullResponseWithBody[i + baseResponseWithoutBody.Length] = this.Content[i];
            }

            return fullResponseWithBody;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result
                .Append($"{GlobalConstants.HttpOneProtocolFragment} {(int)this.StatusCode} {this.StatusCode.ToString()}")
                .Append(GlobalConstants.HttpNewLine)
                .Append(this.Headers)
                .Append(GlobalConstants.HttpNewLine);

            result.Append(GlobalConstants.HttpNewLine);

            return result.ToString();
        }
    }
}
