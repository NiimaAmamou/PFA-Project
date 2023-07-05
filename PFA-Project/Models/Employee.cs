using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFA_Project.Models
{



     public class Employee
        {
            [Key]
            public int ?Id { get; set; }
            [Required]
            public string Nom { get; set; }
            [Required]
            public string Prenom { get; set; }
            [Required]
            public DateTime Date_naissance { get; set; }
            [Required]
            public string email { get; set; }
            [Required]
            public double Salaire { get; set; }
            [Required]
            public int Heure_Travail { get; set; }
        
            public int ?Heure_Sup { get; set; }
            public string ?Description { get; set; }
            [Display(Name = "Disponibilité")]
            [UIHint("Checkbox")]
        public bool Disponibilite { get; set; }
            [Required]
            public string Login { get; set; }
            [Required]
            public string Password { get; set; }
            [Required]
            [NotMapped]
            public string ConfirmationPass { get; set; }
            public double ?RecetteServ { get; set; }
            public int ?NbrExperience { get; set; }
            [Required]
            public string Role { get; set; }
        public List<Commande>?commandes { get; set; }    
        }
    }


