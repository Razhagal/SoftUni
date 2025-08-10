using SIS.HTTP.Responses;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Http;

namespace IRunes.App.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            return this.View();
        }

        [HttpGet(Url = "/")]
        public HttpResponse IndexSlash()
        {
            return this.Index();
        }

        public HttpResponse Test()
        {
            return this.View();
        }
    }
}
