using Microsoft.AspNetCore.Mvc;
using PFA_Project.Models;

namespace PFA_Project.Controllers
{
    public class ServeurController : Controller
    {
        public ApplicationContext db;
        public ServeurController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult List()
        {
            List<Employee> employees = db.Employees.Where(e => e.Role == "Serveur").ToList();
            return View(employees);
        }
    }
}
