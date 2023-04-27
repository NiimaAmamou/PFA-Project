using System.ComponentModel.DataAnnotations;

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

        public List<Fournitures> Fournitures { get; set; }
    }
}
