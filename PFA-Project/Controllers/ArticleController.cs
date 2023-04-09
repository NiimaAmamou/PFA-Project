using Microsoft.AspNetCore.Mvc;
using PFA_Project.Models;
using System.Reflection.Metadata.Ecma335;

namespace PFA_Project.Controllers
{
    public class ArticleController : Controller
    {
        public ApplicationContext db;

        public ArticleController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult ListArticles()
        {
            List<Article> articles = db.Articles.ToList() ;
            return View(articles);
        }
        public IActionResult Create()
        {
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
            return View(article);
        }
    }
}
