using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace PFA_Project.Models
{
    public class Famille
    {
        public int Id { get; set; }
        public string ?Libelle { get; set; }
         public string ?Couleur{ get; set; }
        public List<Produit> ?produits { get; set; }
    }
}
