using PFA_Project.ModelViews;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFA_Project.Models
{
    public class Fourniture
    {
        public int ?Id { get; set; }
        public Article Article { get; set; }
        [ForeignKey("Article")]
        public int IdArticle { get; set; }
        public Fournisseur Fournisseur { get; set; }
        [ForeignKey("Fournisseur")]
        public int IdFournisseur { get; set; }
        public double Qte { get; set; }

        public Fourniture()
        {

        }
        public Fourniture(FournitureAddViews fv)
        {
            IdArticle = fv.IdArticle;
            IdFournisseur=fv.IdFournisseur;
            Qte = fv.Qte;
        }
    }
}
