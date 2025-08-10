using System.Collections.Concurrent;

namespace SIS.HTTP.Sessions
{
    public class HttpSessionStorage : IHttpSessionStorage
    {
        public const string SessionCookieKey = "SIS_ID";

        private readonly ConcurrentDictionary<string, IHttpSession> sessions;

        public HttpSessionStorage()
        {
            this.sessions = new ConcurrentDictionary<string, IHttpSession>();
        }

        public IHttpSession GetSession(string id)
        {
            return this.sessions.GetOrAdd(id, new HttpSession(id));
        }

        public bool ContainsSession(string id)
        {
            return this.sessions.ContainsKey(id);
        }
    }
}