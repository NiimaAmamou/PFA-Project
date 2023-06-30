using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PFA_Project.Models;
using System.Data;

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
            return RedirectToAction("Ajouter", new { Role = employee.Role });
        }
        public IActionResult Ajouter(String Role)
        {
            ViewBag.role=Role;
            return View();
        }

        [HttpPost]
        public IActionResult Ajouter(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if(employee.Password==employee.ConfirmationPass)
                {
                    db.Employees.Add(employee);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("RecupererRole");
        }
        public IActionResult List()
        {
            ViewBag.EmpRoles = new SelectList(new[] {"Selectionner le role ","Serveur", "Cuisinier", "Caissier"});
            //List<Employee> employees = db.Employees.ToList();
            return View();
        }

        public IActionResult Supprimer(int? id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee != null)
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        public IActionResult Modifier(int? id)
        {
            Employee employee = db.Employees.Find(id);
            ViewBag.role = employee.Role;
            if (id == null || employee == null)
            {
                return RedirectToAction("List");
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult Modifier(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.Password == employee.ConfirmationPass)
                {
                    db.Update(employee);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
    }
}
