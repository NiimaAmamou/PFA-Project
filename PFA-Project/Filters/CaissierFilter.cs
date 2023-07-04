using Microsoft.AspNetCore.Mvc.Filters;

namespace PFA_Project.Filters
{
    public class CaissierFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)//avant l'exec d'action
        {
            if (context.HttpContext.Session.GetString("id") == null)
            {
                context.HttpContext.Response.Redirect("/Login/Login");
            }
        }
        public override void OnActionExecuted(ActionExecutedContext context) //apres l'exec d'action
        {
            if (context.HttpContext.Session.GetString("Role") == "Caissier")
            {
                context.HttpContext.Response.Redirect("/Caissier/List");
            }
        }
    }
}

