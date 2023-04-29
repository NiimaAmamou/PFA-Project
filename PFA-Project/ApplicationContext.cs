﻿using Microsoft.EntityFrameworkCore;
using PFA_Project.Models;

namespace PFA_Project
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Famille> Familles { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Fournisseur> Fournisseur { get; set; }
        public DbSet<Produit>     Produit { get; set; }
        public  DbSet<Categorie> Categories { get; set; }
     //   public DbSet<ProduitArticle> ProduitArticles { get; set; }
        public DbSet<Fourniture> Fournitures { get; set; }

    }
}
