using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PFA_Project.Filters;
using PFA_Project.Models;

namespace PFA_Project.Controllers
{
    [AuthFilter("Caissier")]
    public class CategorieController : Controller
    {
        public ApplicationContext db;
        public CategorieController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult ListCategorie()
        {
            List<Categorie> categories = db.Categories.ToList();
            return View(categories);
        }
        public IActionResult CreateCategorie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategorie(Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(categorie);
                db.SaveChanges();
                return RedirectToAction("ListCategorie");
            }
            return View(categorie);

        }
        public IActionResult DeleteCategorie(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("ListCategorie");
            }
            var cat = db.Categories.Find(id);
            if (cat != null)
            {
                db.Categories.Remove(cat);
                db.SaveChanges();
                return RedirectToAction("ListCategorie");
            }
            return RedirectToAction("ListCategorie");
        }
        public IActionResult EditCategorie(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ListCategorie");
            }
            var cat = db.Categories.Find(id);
            if (cat == null)
            {
                return RedirectToAction("ListCategorie");
            }
            return View(cat);
        }
        [HttpPost]
        public IActionResult EditCategorie(Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                db.Update(categorie);
                db.SaveChanges();
                return RedirectToAction("ListCategorie");
            }
            return View(categorie);
        }
    }

}

