namespace PFA_Project.Models
{
    public class Fournisseur
    {
        public int Id { get; set; }
        public string ?Nom { get; set; }
        public string ?Adresse { get; set; }
        public string ?N_Tel { get; set; }
        public string ?Email { get; set; }
        public bool ?Statut { get; set; }
        public List<Fourniture> ?Fournitures { get; set; }
    }
}
