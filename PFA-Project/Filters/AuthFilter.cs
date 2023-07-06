using Microsoft.AspNetCore.Mvc.Filters;

namespace PFA_Project.Filters
{
    public class AuthFilter:ActionFilterAttribute
    {
        public string role;
        public AuthFilter(string role)
        {
            this.role = role;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.HttpContext.Session.GetString("Login")!=null)
            {
                if(context.HttpContext.Session.GetString("Role") != role)
                {
                    context.HttpContext.Response.Redirect("/Login/Login");
                }
                
            }
            else
            {
                context.HttpContext.Response.Redirect("/Login/Login");
            }
        }
    }
}
