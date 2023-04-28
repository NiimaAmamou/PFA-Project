namespace PFA_Project.Models
{
    public class CategorieArticle
    {
        public int? IdArticle { get; set; }
        public string? RefArticle { get; set; }
        public string? LibelleArticle { get; set; }

        public int QteStock { get; set; }
        public string? Unite { get; set; }
        public string ?LibelleCategorie { get; set; }
    }
}
