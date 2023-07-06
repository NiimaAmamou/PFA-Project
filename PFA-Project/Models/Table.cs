using System.ComponentModel.DataAnnotations;

namespace PFA_Project.Models
{
    public class Table
    {
        [Key]
        public int Id { get; set; }
        public int NumTable { get; set; }
        public string ?Capacite { get; set; }
        public string ?EtatTable { get; set; }
        public string ?Description { get; set; }
        public List<Commande>? Commandes { get; set; }


    }
}
