using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PFA_Project.Models;

namespace PFA_Project.Controllers
{
    public class EmployeeController : Controller
    {
        public ApplicationContext db;
        public EmployeeController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult Ajouter()
        {
            ViewBag.EmpRoles=new SelectList(new[] { "Serveur", "Cuisinier", "Caissier", "Admin" });
            return View();
        }
        [HttpPost]
        [Route("Employee/Ajouter")]
        public IActionResult Ajouter(String Role)
        {
            ViewBag.role=Role;
            return View();
        }

        [HttpPost]
        [Route("Employee/Ajouter",Order =1)]
        public IActionResult Ajouter(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            return RedirectToAction("Ajouter");
        }

    }
}
