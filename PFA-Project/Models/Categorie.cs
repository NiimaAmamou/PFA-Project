using System.ComponentModel.DataAnnotations;

namespace PFA_Project.Models
{
    public class Categorie
    {
        [Key]
        public int IdCategorie { get; set; }
        public string? LibelleCategorie { get; set; }
        public List<Article> ?Articles { get; set; }
    }
}
