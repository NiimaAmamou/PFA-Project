using System.ComponentModel.DataAnnotations;

namespace PFA_Project.Models
{
    public class Commande
    {
        [Key]
        public int Id { get; set; }
        public DateTime Datecmd { get; set; }
        public bool Encaisse { get; set; }
        public string? Etat { get; set; }
        public List<LigneCommande>? lignecommande { get; set; }
        public Employee? Employee { get; set; }
        public int EmployeeId { get; set; }
        public Table? Table { get; set; }
        public int TableId { get; set; }
    }
}
