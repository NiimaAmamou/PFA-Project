using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using PFA_Project.Filters;
using PFA_Project.Models;

namespace PFA_Project.Controllers
{
    [AuthFilter("Caissier")]
    public class TableController : Controller
    {
        public ApplicationContext db;
        public TableController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult ListTable()
        {
            List<Table> tables = db.Tables.ToList();
            return View(tables);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Table table)
        {
            if (ModelState.IsValid)
            {
                db.Tables.Add(table);
                db.SaveChanges();
                return RedirectToAction("ListTable");
            }
            return View(table);
        }
        public IActionResult Update(int id)
        {
            Table t = db.Tables.Single(t => t.Id == id);
            return View(t);
        }
        [HttpPost]
        public IActionResult Update(Table table)
        {
            if (ModelState.IsValid)
            {
                db.Update(table);
                db.SaveChanges();
                return RedirectToAction("ListTable");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            Table t = db.Tables.Single(t => t.Id == id);
            db.Remove(t);
            db.SaveChanges();
            return RedirectToAction("ListTable");
        }
    }
}
