using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PFA_Project.Filters;
using PFA_Project.Models;

namespace PFA_Project.Controllers
{
   /* [AuthFilter("Serveur")]
    [AuthFilter("Caissier")]
    [AuthFilter("Admin")]*/
    public class CommandeController : Controller
    {
        public ApplicationContext db;
        public CommandeController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult ListCommandes()
        {
            ViewBag.produits = db.Produits.ToList();
            List<Commande> lists = db.Commandes.Include(c => c.lignecommande).Include(t => t.Table).Include(s => s.Employee).ToList();
            return View(lists);
        }
    }
}