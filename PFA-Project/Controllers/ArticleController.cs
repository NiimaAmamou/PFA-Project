using Microsoft.AspNetCore.Mvc;
using PFA_Project.Models;

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

    }
}
