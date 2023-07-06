using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PFA_Project.Filters;
using PFA_Project.Models;
using System.Reflection.Metadata.Ecma335;
//test
namespace PFA_Project.Controllers
{

    [AuthFilter("admin")]
    public class ArticleController : Controller
    {
        public ApplicationContext db;

        public ArticleController(ApplicationContext db)
        {
            this.db = db;
        }
       
        public IActionResult ListArticles()
        {
            List<CategorieArticle> articles = db.Categories.Join(db.Articles, a => a.IdCategorie,c=>c.IdCat,(Categorie,Article)=> new {Categorie=Categorie, Article=Article})
                 .Select(outpout => new CategorieArticle
                 {
                     IdArticle = outpout.Article.IdArticle,
                     RefArticle = outpout.Article.RefArticle,
                     LibelleArticle = outpout.Article.LibelleArticle,
                     QteStock = outpout.Article.QteStock,
                     Unite = outpout.Article.Unite,
                     LibelleCategorie=outpout.Categorie.LibelleCategorie
                 })
            .ToList();
            return View(articles);
        }
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Categories, "IdCategorie", "LibelleCategorie");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Article article)
        {
            if(ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("ListArticles");
            }
            ViewBag.Categories = new SelectList(db.Categories, "IdCategorie", "LibelleCategorie");
            return View(article);

        }
        public IActionResult Delete(int ?id)
        {
          
            if(id==null)
            {
                return RedirectToAction("ListArticles");
            }
            var ar = db.Articles.Find(id);
            if (ar != null)
            {
                db.Articles.Remove(ar);
                db.SaveChanges();
                return RedirectToAction("ListArticles");
            }
            return RedirectToAction("ListArticles");
        }
        public IActionResult Edit(int ?id)
        {
            if (id == null)
            {
                return RedirectToAction("ListArticles");
            }
            var ar = db.Articles.Find(id);
            if (ar == null)
            {
                return RedirectToAction("ListArticles");
            }
            ViewBag.Categories = new SelectList(db.Categories, "IdCategorie", "LibelleCategorie");
            return View(ar);
        }
        [HttpPost]
        public IActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Update(article);
                db.SaveChanges();
                return RedirectToAction("ListArticles");
            }
            ViewBag.Categories = new SelectList(db.Categories, "IdCategorie", "LibelleCategorie");
            return View(article);
        }
    }
}
