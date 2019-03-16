using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWeb.Filter
{
    class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.Session.GetString("usuario");

            if(String.IsNullOrEmpty(user))
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new
                    {
                        area = "login",
                        controller = "Usuario",
                        action = "Login"
                    }));
            }
        }
    }
}
