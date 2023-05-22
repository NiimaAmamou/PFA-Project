using System.ComponentModel.DataAnnotations;

namespace PFA_Project.Models
{
    public class Commande
    {
        [Key]
             public int Id { get; set; }
             public DateTime Datecmd { get; set; }
             public bool Encaisse { get; set; }
        public String ?Etat { get; set; }
        public List<LigneCommande> ?lignecommande { get; set; }

    }
}
