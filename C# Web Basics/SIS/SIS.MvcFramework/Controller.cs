using SIS.HTTP.Common;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;

using SIS.MvcFramework.Extensions;
using SIS.MvcFramework.Identity;
using SIS.MvcFramework.Results;
using SIS.MvcFramework.Validation;
using SIS.MvcFramework.ViewEngine;

using System.Runtime.CompilerServices;

namespace SIS.MvcFramework
{
    public abstract class Controller
    {
        private readonly IViewEngine viewEngine;

        protected Controller()
        {
            this.viewEngine = new SisViewEngine();
            this.ModelState = new ModelStateDictionary();
        }

        public IdentityUser? User =>
            this.Request.Session.ContainsParameter(GlobalConstants.IdentityUserSessionParam) ?
                (IdentityUser)this.Request.Session.GetParameter(GlobalConstants.IdentityUserSessionParam) : null;

        public IHttpRequest Request { get; set; } = null!;

        public ModelStateDictionary ModelState { get; set; }

        protected HttpResponse View([CallerMemberName] string view = null)
        {
            return this.View<object>(null, view);
        }

        protected HttpResponse View<T>(T model = null, [CallerMemberName] string view = null)
            where T : class
        {
            string controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            string viewName = view;

            string viewContent = System.IO.File.ReadAllText($"Views/{controllerName}/{viewName}.html");
            viewContent = this.viewEngine.GetHtml(viewContent, model, this.ModelState, this.User);

            string layoutContent = System.IO.File.ReadAllText("Views/_Layout.html");
            layoutContent = this.viewEngine.GetHtml(layoutContent, model, this.ModelState, this.User);
            layoutContent = layoutContent.Replace("@RenderBody()", viewContent);

            var htmlResult = new HtmlResult(layoutContent);
            return htmlResult;
        }

        protected void SignIn(string id, string username, string email)
        {
            this.Request.Session.AddParameter(GlobalConstants.IdentityUserSessionParam, new IdentityUser
            {
                Id = id,
                Username = username,
                Email = email
            });
        }

        protected void SignOut()
        {
            this.Request.Session.ClearParameters();
        }

        protected bool IsLoggedIn()
        {
            return this.Request.Session.ContainsParameter(GlobalConstants.IdentityUserSessionParam);
        }

        protected HttpResponse Redirect(string url)
        {
            return new RedirectResult(url);
        }

        protected HttpResponse NotFound(string message = "")
        {
            return new NotFoundResult(message);
        }

        protected HttpResponse File(byte[] fileContent)
        {
            return new FileResult(fileContent);
        }

        protected HttpResponse Json(object obj)
        {
            return new JsonResult(obj.ToJson());
        }

        protected HttpResponse Xml(object obj)
        {
            return new XmlResult(obj.ToXml());
        }
    }
}
