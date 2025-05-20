using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace iKronos
{

    //
    public class AuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        public override void OnAuthorization (AuthorizationContext filterContext)
        {


            //if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
            //    || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            //{
            //    // Don't check for authorization as AllowAnonymous filter is applied to the action or controller
            //    return;
            //}

            //Check for authorization //RedirectToAction("Login", "Login");


           


            if ((HttpContext.Current.Session["user"] == null)   ) //|| (HttpContext.Current.Session["user"] == ""))
            {
                //filterContext.Result =  new HttpUnauthorizedResult();
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                                                    { "controller", "Login" },
                                                    { "action", "Login" }
                });

                }
            }
    }
}