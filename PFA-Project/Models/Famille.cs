using System.ComponentModel.DataAnnotations.Schema;

namespace PFA_Project.Models
{
    public class Famille
    {
        public int ?Id { get; set; }
        public string Libelle { get; set; }
        public string ?Image { get; set; }

        [NotMapped]
        public IFormFile image1 { get; set; }
    }
}
