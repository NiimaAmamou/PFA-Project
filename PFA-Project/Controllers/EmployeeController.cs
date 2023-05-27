using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PFA_Project.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Ajouter()
        {
            ViewBag.EmpRoles=new SelectList(new[] { "Serveur", "Cuisinier", "Caissier", "Admin" });
            return View();
        }
    }
}
