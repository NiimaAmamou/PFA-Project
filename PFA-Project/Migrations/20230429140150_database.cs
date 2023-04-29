using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFA_Project.Migrations
{
    public partial class database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Produit",
                table: "Produit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fournisseur",
                table: "Fournisseur");

            migrationBuilder.RenameTable(
                name: "Produit",
                newName: "Produits");

            migrationBuilder.RenameTable(
                name: "Fournisseur",
                newName: "Fournisseurs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produits",
                table: "Produits",
                column: "IdProduit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fournisseurs",
                table: "Fournisseurs",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Produits",
                table: "Produits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fournisseurs",
                table: "Fournisseurs");

            migrationBuilder.RenameTable(
                name: "Produits",
                newName: "Produit");

            migrationBuilder.RenameTable(
                name: "Fournisseurs",
                newName: "Fournisseur");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produit",
                table: "Produit",
                column: "IdProduit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fournisseur",
                table: "Fournisseur",
                column: "Id");
        }
    }
}
