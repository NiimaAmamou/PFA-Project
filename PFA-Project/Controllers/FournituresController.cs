using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PFA_Project.Filters;
using PFA_Project.Models;
using PFA_Project.ModelViews;

namespace PFA_Project.Controllers
{
    [AuthFilter("admin")]
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
        public IActionResult Modifier(int? id)
        {
            ViewBag.ListArticle = new SelectList(db.Articles.ToList(), "IdArticle", "LibelleArticle");
            ViewBag.ListFournisseur = new SelectList(db.Fournisseurs.ToList(), "Id", "Nom");
            Fourniture fo = db.Fournitures.Find(id);
            /*FournitureAddViews fv = new FournitureAddViews(fo);*/
            if (id == null || fo == null)
            {
                return RedirectToAction("List");
            }
            return View(fo);
        }
        [HttpPost]
        public IActionResult Modifier(Fourniture fv)
        {
            if (ModelState.IsValid)
            {
                db.Update(fv);//3laach raha kat ajouter blast madir modifier 
                db.SaveChanges();

            }
            return RedirectToAction("List");

        }
        public IActionResult Supprimer(int? id)
        {
            var fourniture = db.Fournitures.Find(id);
            if (fourniture != null)
            {
                db.Fournitures.Remove(fourniture);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
