
using SIS.HTTP.Common;

namespace SIS.HTTP.Headers
{
    public class HttpHeader
    {
        public HttpHeader(string key, string value)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

            this.Key = key;
            this.Value = value;
        }

        public string Key { get; } = null!;

        public string Value { get; } = null!;

        public override string ToString()
        {
            return $"{this.Key}: {this.Value}";
        }
    }
}
