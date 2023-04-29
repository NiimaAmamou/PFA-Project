using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFA_Project.Models
{
    public class ProduitArticle
    {
        [Key]
        public int ?Id { get; set; }
        
        public Produit? produit { get; set; }
        [ForeignKey("Produit")]
        public int IdProduit { get; set; }

      
        public Article ?article { get; set; }
        [ForeignKey("Article")]
        public int IdArticle { get; set; }

        public int ?Quantite { get; set; }
    }
}
