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
        public IActionResult RecupererRole()
        {
            ViewBag.EmpRoles = new SelectList(new[] { "Serveur", "Cuisinier", "Caissier", "Admin" });
            return View();
        }
        [HttpPost]
        public IActionResult RecupererRole(Employee employee)
        {
            return RedirectToAction("Ajouter", employee.Role);
        }
        public IActionResult Ajouter(String Role)
        {
            ViewBag.role=Role;
            return View();
        }

        [HttpPost]
        [Route("Employee/Ajouter")]
        public IActionResult AjouterEmp(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            return RedirectToAction("Ajouter");
        }
        public IActionResult List()
        {
            ViewBag.EmpRoles = new SelectList(new[] { "Tous","Serveur", "Cuisinier", "Caissier", "Admin" });
            List<Employee> employees = db.Employees.ToList();
            return View();
        }*/
    }
}
