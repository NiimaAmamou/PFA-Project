using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PFA_Project.Models;
using System.Collections.Generic;

namespace PFA_Project.Controllers
{
    public class ProduitController : Controller
    {
        public ApplicationContext db;
        public ProduitController(ApplicationContext db)
        {
            this.db = db;
        }
     
        public IActionResult ListProduit()
        {
            List<FamilleProduit> produits = db.Familles.Join(db.Produit, p => p.Id,f => f.IdFamille,(Famille, Produit) => new { Famille = Famille, Produit = Produit })
               .Select(outpout => new FamilleProduit
                   {
                       IdProduit = outpout.Produit.IdProduit,
                       LibelleProduit = outpout.Produit.LibelleProduit,
                       Prix = outpout.Produit.Prix,
                       Image = outpout.Produit.Image,
                       LibelleFamille = outpout.Famille.Libelle,
                       
                   })
            .ToList();
            return View(produits);
        }
        public IActionResult AjouterProduit()
        {
            ViewBag.Familles = new SelectList(db.Familles.ToList(), "Id", "Libelle");
            return View();
        }
        [HttpPost]
        public IActionResult AjouterProduit(Produit produit)
        {
            if (ModelState.IsValid)
            {
                string[] allowedExtentions = { ".jpg", ".png", ".jpeg" };
                string fileExtention = Path.GetExtension(produit.image1.FileName).ToLower();
                if (allowedExtentions.Contains(fileExtention))
                {
                    string newName = Guid.NewGuid() +produit.image1.FileName;
                    string pathName = Path.Combine("wwwroot/ImgProduit", newName);
                    produit.Image = newName;
                    using (FileStream stream = System.IO.File.Create(pathName))
                    {
                        produit.image1.CopyTo(stream);
                        db.Produit.Add(produit);
                        db.SaveChanges();
                    }
                }
            }
            ViewBag.Familles = new SelectList(db.Familles.ToList(), "Id", "Libelle");
            return RedirectToAction("ListProduit");

        }
        public IActionResult EditProduit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ListProduit");
            }
            var pr = db.Produit.Find(id);
            if (pr == null)
            {
                return RedirectToAction("ListProduit");
            }
            ViewBag.Familles = new SelectList(db.Familles.ToList(), "Id", "Libelle");
            return View(pr);
        }
        [HttpPost]
        public IActionResult EditProduit(Produit produit)
        {
            if (ModelState.IsValid)
            {
                string[] allowedExtentions = { ".jpg", ".png", ".jpeg" };
                string fileExtention = Path.GetExtension(produit.image1.FileName).ToLower();
                if (allowedExtentions.Contains(fileExtention))
                {
                    string newName = Guid.NewGuid() + produit.image1.FileName;
                    string pathName = Path.Combine("wwwroot/ImgProduit", newName);
                    produit.Image = newName;
                    using (FileStream stream = System.IO.File.Create(pathName))
                    {
                        produit.image1.CopyTo(stream);
                        db.Update(produit);
                        db.SaveChanges();
                    }
                }
            }
            ViewBag.Familles = new SelectList(db.Familles.ToList(), "Id", "Libelle");
            return RedirectToAction("ListProduit");
        }
        public IActionResult DeleteProduit(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("ListProduit");
            }
            var pr = db.Produit.Find(id);
            if (pr != null)
            {
                db.Produit.Remove(pr);
                db.SaveChanges();
                return RedirectToAction("ListProduit");
            }
            return RedirectToAction("ListProduit");
        }

    }
}
