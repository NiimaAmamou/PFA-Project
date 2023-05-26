using Microsoft.EntityFrameworkCore;
using PFA_Project.Models;

namespace PFA_Project
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Famille> Familles { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<ArticleProduit> ArticleProduits { get; set; }
        public DbSet<Fourniture> Fournitures { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<LigneCommande> LigneCommande { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Serveur> Serveurs { get; set; }
        public DbSet<Cuisinier> Cuisiniers { get; set; }
        public DbSet<Caissier> Caissiers { get; set; }

        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Serveur>().ToTable("Serveurs");
            modelBuilder.Entity<Cuisinier>().ToTable("Cuisiniers");
            modelBuilder.Entity<Caissier>().ToTable("Caissiers");
        }
    }
}

