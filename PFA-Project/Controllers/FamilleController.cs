using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PFA_Project.Models;
using System.Drawing;

namespace PFA_Project.Controllers
{
    [Authorize]
    public class FamilleController : Controller
    {
        public ApplicationContext db;

        public FamilleController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult List()
        {
            List<Famille> familles = db.Familles.ToList();
            return View(familles);
        }
        public IActionResult Ajouter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ajouter(Famille famille)
        {
            if (ModelState.IsValid)
            {
                //ayakhod le type hexadecimal o k anffectewha lcouleur
              //  string hex = famille.Couleur.R.ToString("X2") + famille.Couleur.G.ToString("X2") + famille.Couleur.B.ToString("X2");
               // famille.Couleur = hex;
                db.Familles.Add(famille);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(famille);
        }
        public IActionResult Modifier(int ?id)
        {
        if (id == null)
        {
            return RedirectToAction("List");
        }
        var fa = db.Familles.Find(id);
        if (fa == null)
        {
            return RedirectToAction("List");
        }
        return View(fa);
    }
        [HttpPost]
        public IActionResult Modifier(Famille famille)
        {
            if (ModelState.IsValid)
            {
                //string hex = famille.Couleur1.R.ToString("X2") + famille.Couleur1.G.ToString("X2") + famille.Couleur1.B.ToString("X2");
               // famille.Couleur = hex;
                db.Update(famille);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(famille);
       
        }
        public IActionResult Supprimer(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List");
            }
            var famille = db.Familles.Find(id);
            if (famille != null)
            {
                db.Familles.Remove(famille);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }
    }
}
