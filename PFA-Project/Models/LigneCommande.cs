using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PFA_Project.Models
{
    public class LigneCommande
    {
        [Key]
        public int Id { get; set; }
        public Produit? produit { get; set; }
   
        public int ProduitId { get; set; }
        public Commande? commande { get; set; }
      
        public int CommandeId { get; set; }
        public int? Quantite { get; set; }
        public double? Prix { get; set; }
       
    }
}
