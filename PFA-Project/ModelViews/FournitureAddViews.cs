using PFA_Project.Models;

namespace PFA_Project.ModelViews
{
    public class FournitureAddViews
    {
        public int IdArticle { get; set; }
        public int IdFournisseur { get; set; }
        public double Qte { get; set; }

        public FournitureAddViews()
        {

        }
        public FournitureAddViews(Fourniture f)
        {
            IdArticle = f.IdArticle;
            IdFournisseur = f.IdFournisseur;
            Qte = f.Qte;
        }
    }
}
