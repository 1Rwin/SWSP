using System.Web.Mvc;
using System.Web.Routing;

namespace SWSPapp.Services
{
    public class AuthAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (SessionPersister.User == null)
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Session", action = "Login" }));
        }
    }
}