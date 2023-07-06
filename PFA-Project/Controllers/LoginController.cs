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
        
        public IActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
         public IActionResult Login(EmployeeViews e)
         {
             if(ModelState.IsValid)
             {
                 Employee a = db.Employees.Where(a => a.Login.Equals(e.Login) && a.Password.Equals(e.Password)).FirstOrDefault();
                 if(a!=null)
                    { 
                    HttpContext.Session.SetString("Login", a.Login);
                    HttpContext.Session.SetString("Role", a.Role);
                    return RedirectToAction("Index", "Home");
                 }
                 else
                 {
                     ViewBag["validateMess"] = "User not found";
                     return View(e);
                 }
             }
             return View();
         }
        public IActionResult LogOut() 
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
