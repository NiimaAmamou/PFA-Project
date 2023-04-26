﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PFA_Project;

#nullable disable

namespace PFA_Project.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230408221046_Hanae")]
    partial class Hanae
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PFA_Project.Models.Article", b =>
                {
                    b.Property<int>("IdArticle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArticle"), 1L, 1);

                    b.Property<string>("LibelleArticle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QteStock")
                        .HasColumnType("int");

                    b.Property<string>("RefArticle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdArticle");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("PFA_Project.Models.Famille", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Familles");
                });

            modelBuilder.Entity("PFA_Project.Models.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Capacite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EtatTable")
                        .HasColumnType("bit");

                    b.Property<int>("NumTable")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tables");
                });
#pragma warning restore 612, 618
        }
    }
}