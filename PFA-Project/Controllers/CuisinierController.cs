using Microsoft.AspNetCore.Mvc;
using PFA_Project.Models;

namespace PFA_Project.Controllers
{
    public class CuisinierController : Controller
    {
        public ApplicationContext db;
        public CuisinierController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult List()
        {
            List<Employee> employees = db.Employees.Where(e => e.Role == "Cuisinier").ToList();
            return View(employees);
        }
    }
}
