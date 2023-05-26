using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Zap.Models;

namespace Zap.Filters
{
    public class AdminFilter : Attribute, IActionFilter
    {
        public AdminFilter()
        {

        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Prima che si esegua l'autenticazione
            RegistrationHandling g = new RegistrationHandling(context.HttpContext.Session);
            if (g.GiveUserRole().ToString() != "Admin")
            {
                context.Result = new BadRequestObjectResult("Administrator only zone. This incident will be reported");
                return;
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Dopo che si esegua l'autenticazione
        }
    }
}
