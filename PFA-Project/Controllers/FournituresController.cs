using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PFA_Project.Models;
using PFA_Project.ModelViews;

namespace PFA_Project.Controllers
{
    public class FournituresController : Controller
    {
        public ApplicationContext db;
        public FournituresController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult List()
        {
            List<Fourniture> fournitures = db.Fournitures.Include(f=>f.Fournisseur).Include(f=>f.Article).ToList();
            return View(fournitures);
        }
        public IActionResult Ajouter()
        {
            ViewBag.ListArticle = new SelectList(db.Articles.ToList(), "IdArticle", "LibelleArticle");
            ViewBag.ListFournisseur = new SelectList(db.Fournisseurs.ToList(), "Id", "Nom");
            return View();
        }
        [HttpPost]
        public IActionResult Ajouter(FournitureAddViews fv)
        {
            if (ModelState.IsValid)
            {
                Fourniture fn = new Fourniture(fv);
                fn.Article = db.Articles.Find(fv.IdArticle);
                fn.Fournisseur = db.Fournisseurs.Find(fn.IdFournisseur);

                db.Fournitures.Add(fn);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
