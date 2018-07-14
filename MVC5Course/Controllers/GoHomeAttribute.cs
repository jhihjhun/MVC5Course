using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class GoHomeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Result = new RedirectResult("/");
        }
    }
}