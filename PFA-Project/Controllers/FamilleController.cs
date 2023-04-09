using Microsoft.AspNetCore.Mvc;
using PFA_Project.Models;

namespace PFA_Project.Controllers
{
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
                string[] allowedExtentions = { ".jpg", ".png", ".jpeg" };
                string fileExtention = Path.GetExtension(famille.image1.FileName).ToLower();
                if (allowedExtentions.Contains(fileExtention))
                {
                    string newName = Guid.NewGuid() + famille.image1.FileName;
                    string pathName = Path.Combine("wwwroot", newName);
                    famille.Image = newName;
                    using (FileStream stream = System.IO.File.Create(pathName))
                    {
                        famille.image1.CopyTo(stream);
                        db.Familles.Add(famille);
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("List");

        }
        public IActionResult Modifier(int id)
        {
            Famille famille = db.Familles.Single(famille => famille.Id == id);
            return View(famille);
        }
        [HttpPost]
        public IActionResult Modifier(Famille famille)
        {
            if (ModelState.IsValid)
            {
                string[] allowedExtentions = { ".jpg", ".png", ".jpeg" };
                string fileExtention = Path.GetExtension(famille.image1.FileName).ToLower();
                if (allowedExtentions.Contains(fileExtention))
                {
                    string newName = Guid.NewGuid() + famille.image1.FileName;
                    string pathName = Path.Combine("wwwroot", newName);
                    famille.Image = newName;
                    using (FileStream stream = System.IO.File.Create(pathName))
                    {
                        famille.image1.CopyTo(stream);
                        db.Update(famille);
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("List");
        }
        public IActionResult Delete(int? id)
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
