using System.ComponentModel.DataAnnotations;

namespace PFA_Project.Models
{
    public  class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Date_naissance { get; set; }
        public string email { get; set; }
        public double Salaire { get; set; }
        public int Heure_Travail { get; set; }
        public int Heure_Sup { get; set; }
        public string Description { get; set; }
        public Boolean Disponibilite { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public double RecetteServ { get; set; }
        public int NbrExperience { get; set; }
        public String Role { get; set; }
    }
}
