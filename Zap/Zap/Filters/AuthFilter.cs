using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Zap.Models;
using System;
using System.IO;

namespace Zap.Filters
{
    public class AuthFilter : Attribute, IActionFilter
    {
        public AuthFilter()
        {

        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Prima che si esegua l'autenticazione
            RegistrationHandling g = new RegistrationHandling(context.HttpContext.Session);
            if (g.GiveUserRole().ToString() != "Guest")
            {
                context.Result = new BadRequestObjectResult("You're already logged! Log out to change account!");
                return;
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Dopo che si esegua l'autenticazione
        }
    }
}
