using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFA_Project.Migrations
{
    public partial class crudCat2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdArticle",
                table: "Produit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProduitArticle",
                table: "Produit",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdArticle",
                table: "Produit");

            migrationBuilder.DropColumn(
                name: "IdProduitArticle",
                table: "Produit");
        }
    }
}
