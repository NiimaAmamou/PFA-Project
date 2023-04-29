using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFA_Project.Migrations
{
    public partial class PAA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdArticle",
                table: "Produit");

            migrationBuilder.AddColumn<int>(
                name: "IdArticle",
                table: "ProduitArticles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProduit",
                table: "ProduitArticles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdArticle",
                table: "ProduitArticles");

            migrationBuilder.DropColumn(
                name: "IdProduit",
                table: "ProduitArticles");

            migrationBuilder.AddColumn<int>(
                name: "IdArticle",
                table: "Produit",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
