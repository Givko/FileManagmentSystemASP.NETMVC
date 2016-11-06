using System.Web.Mvc;
using FileManagmentSystem.App.Authentication;

namespace FileManagmentSystem.App.Attributes
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AuthenticationManager.LoggedUser == null)
            {
                // If there is no user logged - redirect to login page with RedirectUrl parameter
                filterContext.HttpContext.Response.Redirect("~/Home/Login/?RedirectUrl=" + filterContext.HttpContext.Request.Url);
                filterContext.Result = new EmptyResult();
                return;
            }

        }
    }
}
