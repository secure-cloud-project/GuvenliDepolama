using GuvenliDepolama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuvenliDepolama.Attribute
{
    class SessionAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["User"] == null || HttpContext.Current.Session["User"] == "")
            {
                filterContext.HttpContext.Response.Redirect("/Secure/login");
            }            

            //var a = HttpContext.Current.User.Identity.Name;
            //if (!HttpContext.Current.User.Identity.IsAuthenticated)
            //{
            //    if (!HttpContext.Current.Response.IsRequestBeingRedirected)
            //        filterContext.HttpContext.Response.Redirect("/Secure/login");
            //}
        }
    }
}