using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PFA_Project.Models;
using System.Diagnostics;

namespace PFA_Project.Controllers
{
    public class HomeController : Controller
    {
        public List<Famille> famillesCache;
        public ApplicationContext db;
        private readonly IMemoryCache memoryCache;
        private readonly string cachekey = "KeyFamille";
        private readonly ILogger logger;
        public HomeController(ApplicationContext db, ILogger<ProduitController> logger, IMemoryCache memoryCache)
        {
            this.db = db;
            this.memoryCache = memoryCache;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            VerifierCache();
            ViewBag.familles = famillesCache;
            List<FamilleProduit> produits = famillesCache.Join(db.Produits, p => p.Id, f => f.IdFamille, (Famille, Produit) => new { Famille = Famille, Produit = Produit })
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
            if (memoryCache.TryGetValue(cachekey, out famillesCache))
            {
                //log kay3tiwna les infos dial ina controller rana fih u les messages li etito daba
                logger.Log(LogLevel.Information, "Familles found in cache.");
            }
            else
            {
                logger.Log(LogLevel.Information, "Familles not found in cache.");
                famillesCache = db.Familles.ToList();
                memoryCache.Set(cachekey, famillesCache);

            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}