using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Responses;
using System.Text;

namespace SIS.MvcFramework.Results
{
    public class JsonResult : HttpResponse
    {
        public JsonResult(string jsonContent, HttpResponseStatusCode httpResponseStatusCode = HttpResponseStatusCode.Ok)
            : base(httpResponseStatusCode)
        {
            this.AddHeader(new HttpHeader(HttpHeader.ContentType, "application/json"));
            this.Content = Encoding.UTF8.GetBytes(jsonContent);
        }
    }
}
