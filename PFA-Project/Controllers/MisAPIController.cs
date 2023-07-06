using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PFA_Project.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PFA_Project.Controllers
{
    [Route("api/MisAPI")]
    [ApiController]
    public class MisAPIController : ControllerBase
    {
        private readonly ApplicationContext db;
        public MisAPIController(ApplicationContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public ActionResult GetAllProduits()
        {
            try
            {
                List<FamilleProduit> produits = db.Produits.Join(db.Familles, p => p.IdFamille, f => f.Id, (p, f) => new { p, f })
                    .OrderBy(x => x.f.Libelle).Select(p => new FamilleProduit
                    {
                        IdProduit = p.p.IdProduit,
                        LibelleFamille = p.f.Libelle,
                        LibelleProduit = p.p.LibelleProduit,
                        Prix = p.p.Prix

                    }).ToList();
                return Ok(new { r = "Oui", produits = produits });
            }
            catch
            {
                return Ok(new { r = "Non" });
            }
        }
        [HttpGet("servers")]
        public ActionResult GetAllServers()
        {
            try
            {
                var servers = db.Employees.Where(x => x.Disponibilite == true && x.Role == "Serveur").ToList();
                return Ok(new { r = "Oui", servers = servers });
            }
            catch
            {
                return Ok(new { r = "Non" });
            }
        }
        [HttpGet("tables")]
        public ActionResult GetAllDispTables()
        {
            try
            {
                var tables = db.Tables.Where(x => x.EtatTable == "Disponible").ToList();
                return Ok(new { r = "Oui", tables = tables });
            }
            catch
            {
                return Ok(new { r = "Non" });
            }
        }
        [HttpPost]
        public IActionResult CreateCommande([FromBody] CmdDataModel cmd)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Commande c = new Commande()
                    {
                        Encaisse = false,
                        Etat = "EnCours",
                        Datecmd = DateTime.Now,
                        //serveur dans cmddatamodel est lui l'employee et meme pour la table
                        EmployeeId = int.Parse(cmd.server),
                        TableId = int.Parse(cmd.table)
                    };
                    db.Commandes.Add(c);
                    db.SaveChanges();
                    string[] prods = cmd.produits.Split(',');
                    string[] qnts = cmd.qnts.Split(',');

                    int i = 0;
                    foreach (string idproduit in prods)
                    {
                        db.LigneCommande.Add(new LigneCommande()
                        {
                            CommandeId = c.Id,
                            ProduitId = int.Parse(idproduit),
                            Quantite = int.Parse(qnts[i]),
                            Prix = db.Produits.FirstOrDefault(x => x.IdProduit == int.Parse(idproduit)).Prix
                       });
                       i++;
                    }
                    db.SaveChanges();
                    return Ok(new { r = "Oui" });
                }
                else
                {
                    return Ok(new { r = "Non" });
                }
            }
            catch (Exception)
            {
                return Ok(new { r = "Non" });
            }
        }
    }
}