using SIS.HTTP.Common;

namespace SIS.HTTP.Sessions
{
    public class HttpSession : IHttpSession
    {
        private readonly IDictionary<string, object> sessionParameters;

        public HttpSession(string id)
        {
            this.Id = id;
            this.IsNew = true;
            this.sessionParameters = new Dictionary<string, object>();
        }

        public string Id { get; }

        public bool IsNew { get; set; }

        public void AddParameter(string name, object parameter)
        {
            CoreValidator.ThrowIfNull(parameter, nameof(parameter));
            if (!string.IsNullOrEmpty(name))
            {
                this.sessionParameters[name] = parameter;
            }
        }

        public bool ContainsParameter(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            return this.sessionParameters.ContainsKey(name);
        }

        public object GetParameter(string name)
        {
            if (!this.ContainsParameter(name))
            {
                return null;
            }

            return this.sessionParameters[name];
        }

        public void ClearParameters()
        {
            this.sessionParameters.Clear();
        }
    }
}
