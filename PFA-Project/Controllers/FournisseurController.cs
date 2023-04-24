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
            List<Fournisseur> fournisseurs = db.Fournisseur.ToList();
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
                db.Fournisseur.Add(fournisseur);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
