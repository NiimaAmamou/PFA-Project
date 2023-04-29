using Microsoft.AspNetCore.Mvc;
using PFA_Project.Models;

namespace PFA_Project.Controllers
{
    public class FournisseurController : Controller
    {
        public ApplicationContext db;
        public FournisseurController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult List()
        {
            List<Fournisseur> fournisseurs = db.Fournisseurs.ToList();
            return View(fournisseurs);
        }
        public IActionResult Ajouter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ajouter(Fournisseur fournisseur)
        {
            if (ModelState.IsValid)
            {
                db.Fournisseurs.Add(fournisseur);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        public IActionResult Modifier(int? id)
        {
            var fo = db.Fournisseurs.Find(id);
            if (id == null|| fo == null)
            {
                return RedirectToAction("List");
            }
            return View(fo);
        }
        [HttpPost]
        public IActionResult Modifier(Fournisseur fournisseur)
        {
            if (ModelState.IsValid)
            {
                db.Update(fournisseur);
                db.SaveChanges();
                
            }
            return RedirectToAction("List");

        }
        public IActionResult Supprimer(int? id)
        {
            var fournisseur = db.Fournisseurs.Find(id);
            if (fournisseur != null)
            {
                db.Fournisseurs.Remove(fournisseur);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
