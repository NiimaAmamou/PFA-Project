using System.ComponentModel.DataAnnotations;

namespace PFA_Project.Models
{
    public class ProduitArticle
    {
        [Key]
        public int Id { get; set; }
        public Produit produit { get; set; }
        public Article article { get; set; }
        public int Quantite { get; set; }
    }
}
