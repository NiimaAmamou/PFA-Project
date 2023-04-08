using Microsoft.EntityFrameworkCore;
using PFA_Project.Models;

namespace PFA_Project
{
    public class ApplicationContext:DbContext
    {

        public ApplicationContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Famille> Familles { get; set; }
        public DbSet<Table> Tables { get; set; }
    }
}
