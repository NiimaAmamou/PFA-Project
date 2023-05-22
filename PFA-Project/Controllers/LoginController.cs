using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PFA_Project.Models;
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
            if(claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Admin admin)
        {
            if(ModelState.IsValid)
            {
                Admin a = db.Admins.Where(a => a.Login.Equals(admin.Login) && a.Password.Equals(admin.Password)).FirstOrDefault();
                if(a!=null)
                {
                    List<Claim> claims=new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier,admin.Login),
                        
                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                    };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ViewBag["validateMess"] = "User not found";
                    return View();
                }
            }
            return View();
        }
    }
}
