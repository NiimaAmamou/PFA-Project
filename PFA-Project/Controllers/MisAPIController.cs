
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFA_Project;
using PFA_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public ActionResult<IEnumerable<FamilleProduit>> GetAllProduits()
        {
            try
            {
                List<FamilleProduit> produits = db.Produits.Join(db.Familles,p=>p.IdFamille,f=>f.Id,(p,f)=>new { p, f })
                    .OrderBy(x=>x.f.Libelle).Select(p => new FamilleProduit
                {
                    IdProduit = p.p.IdProduit,
                    LibelleFamille = p.f.Libelle,
                    LibelleProduit = p.p.LibelleProduit,
                    Prix = p.p.Prix
           
                }).ToList();
                return Ok(new { r = "Oui", produits = produits });
            }
            catch (Exception )
            {
                return Ok(new {r="Non"});
            }
        }


        [HttpGet("{id}")]
        public ActionResult<Produit> GetProduct(int id)
        {
            try
            {
                var produits = db.Produits.Find(id);
                if (produits != null)
                {
                    return Ok(produits);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult CreateCommande([FromBody] Commande commande)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Commandes.Add(commande);
                    db.SaveChanges();

                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpPost]
        public IActionResult CreateDetailsCommande([FromBody] LigneCommande  lignecommande)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.LigneCommande.Add(lignecommande);
                    db.SaveChanges();

                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        

        
    }
}
