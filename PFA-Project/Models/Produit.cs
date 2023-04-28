﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFA_Project.Models
{
    public class Produit
    {
        [Key]
        public int IdProduit { get; set; }
        public string? LibelleProduit { get; set; }
        public double? Prix { get; set; }
        public string? Image { get; set; }

        [NotMapped]
        public IFormFile image1 { get; set; }
        [ForeignKey("Famille")]
        public int IdFamille { get; set; }
        public Famille famille;
        [ForeignKey("Article")]
        public int IdArticle { get; set; }
        public Article article;
   
        public List<ProduitArticle> produitArticles { get; set; }
    }
}
