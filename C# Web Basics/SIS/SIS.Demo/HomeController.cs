using SIS.HTTP.Requests;
using SIS.HTTP.Responses;

using SIS.WebServer.Results;

namespace SIS.Demo
{
    public class HomeController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            string content = "<h1>Hello from my custom demo server!</h1>";
            return new HtmlResult(content, HTTP.Enums.HttpResponseStatusCode.Ok);
        }
    }
}
