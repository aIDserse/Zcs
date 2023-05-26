using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Zap.Models;
using System;
using System.IO;

namespace Zap.Filters
{
    public class ReservationFilter : Attribute, IActionFilter
    {
        public ReservationFilter()
        {

        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Prima che si esegua l'autenticazione
            RegistrationHandling g = new RegistrationHandling(context.HttpContext.Session);
            if (g.GiveUserRole().ToString() == "Guest")
            {
                context.Result = new BadRequestObjectResult("You have to be logged to access reservations!");
                return;
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Dopo che si esegua l'autenticazione
        }
    }
}
