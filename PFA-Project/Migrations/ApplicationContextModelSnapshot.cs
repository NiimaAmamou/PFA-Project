﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PFA_Project;

#nullable disable

namespace PFA_Project.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PFA_Project.Models.Article", b =>
                {
                    b.Property<int?>("IdArticle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdArticle"), 1L, 1);

                    b.Property<int?>("CategorieIdCategorie")
                        .HasColumnType("int");

                    b.Property<int?>("IdCat")
                        .HasColumnType("int");

                    b.Property<string>("LibelleArticle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QteStock")
                        .HasColumnType("int");

                    b.Property<string>("RefArticle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdArticle");

                    b.HasIndex("CategorieIdCategorie");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("PFA_Project.Models.ArticleProduit", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<int>("IdArticle")
                        .HasColumnType("int");

                    b.Property<int>("IdProduit")
                        .HasColumnType("int");

                    b.Property<int?>("Quantite")
                        .HasColumnType("int");

                    b.Property<int?>("articleIdArticle")
                        .HasColumnType("int");

                    b.Property<int?>("produitIdProduit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("articleIdArticle");

                    b.HasIndex("produitIdProduit");

                    b.ToTable("ArticleProduits");
                });

            modelBuilder.Entity("PFA_Project.Models.Categorie", b =>
                {
                    b.Property<int>("IdCategorie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategorie"), 1L, 1);

                    b.Property<string>("LibelleCategorie")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCategorie");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PFA_Project.Models.Famille", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("Couleur")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Familles");
                });

            modelBuilder.Entity("PFA_Project.Models.Fournisseur", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("N_Tel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Statut")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Fournisseurs");
                });

            modelBuilder.Entity("PFA_Project.Models.Fourniture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdArticle")
                        .HasColumnType("int");

                    b.Property<int>("IdFournisseur")
                        .HasColumnType("int");

                    b.Property<double>("Qte")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdArticle");

                    b.HasIndex("IdFournisseur");

                    b.ToTable("Fournitures");
                });

            modelBuilder.Entity("PFA_Project.Models.Produit", b =>
                {
                    b.Property<int>("IdProduit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduit"), 1L, 1);

                    b.Property<int>("IdFamille")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LibelleProduit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Prix")
                        .HasColumnType("float");

                    b.Property<int?>("familleId")
                        .HasColumnType("int");

                    b.HasKey("IdProduit");

                    b.HasIndex("familleId");

                    b.ToTable("Produits");
                });

            modelBuilder.Entity("PFA_Project.Models.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Capacite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EtatTable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumTable")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("PFA_Project.Models.Article", b =>
                {
                    b.HasOne("PFA_Project.Models.Categorie", null)
                        .WithMany("Articles")
                        .HasForeignKey("CategorieIdCategorie");
                });

            modelBuilder.Entity("PFA_Project.Models.ArticleProduit", b =>
                {
                    b.HasOne("PFA_Project.Models.Article", "article")
                        .WithMany()
                        .HasForeignKey("articleIdArticle");

                    b.HasOne("PFA_Project.Models.Produit", "produit")
                        .WithMany()
                        .HasForeignKey("produitIdProduit");

                    b.Navigation("article");

                    b.Navigation("produit");
                });

            modelBuilder.Entity("PFA_Project.Models.Fourniture", b =>
                {
                    b.HasOne("PFA_Project.Models.Article", "Article")
                        .WithMany("Fournitures")
                        .HasForeignKey("IdArticle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PFA_Project.Models.Fournisseur", "Fournisseur")
                        .WithMany("Fournitures")
                        .HasForeignKey("IdFournisseur")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Fournisseur");
                });

            modelBuilder.Entity("PFA_Project.Models.Produit", b =>
                {
                    b.HasOne("PFA_Project.Models.Famille", "famille")
                        .WithMany("produits")
                        .HasForeignKey("familleId");

                    b.Navigation("famille");
                });

            modelBuilder.Entity("PFA_Project.Models.Article", b =>
                {
                    b.Navigation("Fournitures");
                });

            modelBuilder.Entity("PFA_Project.Models.Categorie", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("PFA_Project.Models.Famille", b =>
                {
                    b.Navigation("produits");
                });

            modelBuilder.Entity("PFA_Project.Models.Fournisseur", b =>
                {
                    b.Navigation("Fournitures");
                });
#pragma warning restore 612, 618
        }
    }
}
