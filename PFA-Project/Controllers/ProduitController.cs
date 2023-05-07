
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using PFA_Project.Models;
using System.Collections.Generic;


namespace PFA_Project.Controllers
{
    public class ProduitController : Controller
    {
        public List<Famille> famillesCache;

        public ApplicationContext db;
        private readonly IMemoryCache memoryCache;
        private readonly string cachekey = "KeyFamille";
        private readonly  ILogger logger;
        public ProduitController(ILogger<ProduitController>logger,ApplicationContext db, IMemoryCache memoryCache)
        {
            this.db = db;
            this.memoryCache = memoryCache;
            this.logger = logger;
           
        }
        public IActionResult ListProduit()
        {
            List<FamilleProduit> produits = db.Familles.Join(db.Produits, p => p.Id,f => f.IdFamille,(Famille, Produit) => new { Famille = Famille, Produit = Produit })
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
        public void VerifierCache()
        {
            // verifier si n'existe pas  une cache concernant famille!
           //kat3mrlina listfamilleCache b b cache
            if(memoryCache.TryGetValue(cachekey,out famillesCache))
            {
                //log kay3tiwna les infos dial ina controller rana fih u les messages li etito daba
                logger.Log(LogLevel.Information, "Familles found in cache."   );
            }
            else
            {
                logger.Log(LogLevel.Information, "Familles not found in cache.");
                famillesCache = db.Familles.ToList();

                memoryCache.Set(cachekey, famillesCache);

            }
        }
        public IActionResult AjouterProduit()
        {
            VerifierCache();
            ViewBag.Familles = new SelectList(famillesCache, "Id", "Libelle");
           
            ViewBag.Articles = new SelectList(db.Articles.ToList(), "IdArticle", "LibelleArticle");

            return View();
        }
        [HttpPost]
        public IActionResult AjouterProduit(Produit produit, string[] id_articles,string[] quantites)
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
                            db.Produits.Add(produit);
                            db.SaveChanges();
                        for(int i=0;i<id_articles.Length;i++)
                        {
                            db.ArticleProduits.Add(new ArticleProduit()
                            {
                                IdProduit = produit.IdProduit,
                                IdArticle = int.Parse(id_articles[i]),
                                Quantite = int.Parse(quantites[i])
                            });
                            db.SaveChanges();
                                

                        }
                        return RedirectToAction("ListProduit");
                        }
                    }
                }
               VerifierCache();
                ViewBag.Familles = new SelectList(famillesCache, "Id", "Libelle");
                List<Article>? articles = db.Articles.ToList();
                ViewBag.Articles = new SelectList(articles, "IdArticle", "LibelleArticle");
                return RedirectToAction("ListProduit");
            }
        
        public IActionResult EditProduit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ListProduit");
            }
            var pr = db.Produits.Find(id);
            if (pr == null)
            {
                return RedirectToAction("ListProduit");
            }
            VerifierCache();
            ViewBag.Familles = new SelectList(famillesCache, "Id", "Libelle");
            List<Article> articles = db.Articles.ToList();
            ViewBag.Articles = new SelectList(articles, "IdArticle", "LibelleArticle");
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
            VerifierCache();
            ViewBag.Familles = new SelectList(famillesCache, "Id", "Libelle");
            List<Article> articles = db.Articles.ToList();
            ViewBag.Articles = new SelectList(articles, "IdArticle", "LibelleArticle");
            return RedirectToAction("ListProduit");
        }
        public IActionResult DeleteProduit(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("ListProduit");
            }
            var pr = db.Produits.Find(id);
            if (pr != null)
            {
                db.Produits.Remove(pr);
                db.SaveChanges();
                return RedirectToAction("ListProduit");
            }
            return RedirectToAction("ListProduit");
        }

    }
}
