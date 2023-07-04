using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PFA_Project.Models;
using PFA_Project.ModelViews;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace PFA_Project.Controllers
{
public class LoginController : Controller
    {
        public ApplicationContext db;

        public LoginController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        //Checking if the user is already logged in
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
         public async Task<IActionResult> Login(EmployeeViews e)
         {
             if(ModelState.IsValid)
             {
                 Employee a = db.Employees.Where(a => a.Login.Equals(e.Login) && a.Password.Equals(e.Password)).FirstOrDefault();
                 if(a!=null)
                 {
                     List<Claim> claims=new List<Claim>
                     {
                         new Claim(ClaimTypes.NameIdentifier,e.Login),

                     };
                     ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                     AuthenticationProperties properties = new AuthenticationProperties()
                     {
                         AllowRefresh = true,
                     };
                 await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);
                        if(a.Role=="Caissier")
                        {
                        return RedirectToAction("List", "Caissier");
                        }
                        else if(a.Role=="Serveur")
                        {
                        return RedirectToAction("List", "Table");
                        }
                 }
                 else
                 {
                     ViewBag["validateMess"] = "User not found";
                     return View(e);
                 }
             }
             return View();
         }
    }
}
