using System.ComponentModel.DataAnnotations;

namespace PFA_Project.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string ? Login { get; set; }
        public string ?Password { get; set; }
    }
}
