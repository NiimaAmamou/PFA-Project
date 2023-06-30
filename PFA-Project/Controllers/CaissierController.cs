using Microsoft.AspNetCore.Mvc;
using PFA_Project.Models;

namespace PFA_Project.Controllers
{
    public class CaissierController : Controller
    {
        public ApplicationContext db;
        public CaissierController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult List()
        {
            List<Employee> employees = db.Employees.Where(e => e.Role == "Caissier").ToList();
            return View(employees);
        }
    }
}
