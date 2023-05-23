using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PFA_Project.Models;

namespace PFA_Project.Controllers
{
    [Authorize]
    public class CommandeController : Controller
    {
        public ApplicationContext db;
        public CommandeController(ApplicationContext db)
        {
            this.db = db;  
        }
        [HttpPost]
        public IActionResult AjouterCommande(string[] idproduit, string[] quantite, string[]prix)
        {
            Commande c = new Commande() { Datecmd = DateTime.Now, Encaisse = false, Etat = "En Cours" };
            db.Commandes.Add(c);
            db.SaveChanges();
                    for (int i = 0; i < idproduit.Length; i++)
                        {
                db.LigneCommande.Add(new LigneCommande()
                {
                    CommandeId = c.Id,
                    ProduitId = int.Parse(idproduit[i]),
                    Quantite = int.Parse(quantite[i]),
                    Prix = float.Parse(prix[i]),
                }) ; 
                            db.SaveChanges();

                        }
                        return RedirectToAction("Index","Home");
                    }
                }
            }