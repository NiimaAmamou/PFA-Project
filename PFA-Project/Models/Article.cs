
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFA_Project.Models
{
    public class Article
    {
        [Key]
        public int ?IdArticle { get; set; }
        public string? RefArticle { get; set; }
        public string ?LibelleArticle { get; set; }
        
        public int QteStock { get; set; }
        public string? Unite { get; set; }

        public List<Fourniture>? Fournitures { get; set; }
        [ForeignKey("Categorie")]
        public int ?IdCat { get; set; }
        public Categorie ?categorie;
      public List<ArticleProduit>? produitArticles { get; set; }
    }
}
