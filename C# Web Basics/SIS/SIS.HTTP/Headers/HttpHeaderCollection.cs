using SIS.HTTP.Common;
using System.Text;

namespace SIS.HTTP.Headers
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly IDictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void AddHeader(HttpHeader header)
        {
            if (header != null)
            {
                this.headers[header.Key] = header;
            }
        }

        public bool ContainsHeader(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }

            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            if (!this.ContainsHeader(key))
            {
                return null;
            }
            
            return this.headers[key];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var header in this.headers)
            {
                sb.AppendLine($"{header.Value.ToString()}{GlobalConstants.HttpNewLine}");
            }

            return sb.ToString().Trim();
        }
    }
}
