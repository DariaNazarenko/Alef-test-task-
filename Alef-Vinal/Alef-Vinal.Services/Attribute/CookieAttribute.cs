using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Alef_Vinal.Services.Attribute
{
    public class CookieAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var res = filterContext.Result.GetType().Name;
            if (res != "BadRequestResult")
            {
                var routeData = filterContext.RouteData.Values;
                var id = routeData["id"];
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddDays(1);
                cookieOptions.IsEssential=true;


                filterContext.HttpContext.Response.Cookies.Append("UpdatedId", id.ToString(), cookieOptions);
            }
        }
    }
}
