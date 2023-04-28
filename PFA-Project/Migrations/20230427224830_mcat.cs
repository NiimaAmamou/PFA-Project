using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFA_Project.Migrations
{
    public partial class mcat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorie",
                table: "Categorie");

            migrationBuilder.RenameTable(
                name: "Categorie",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "IdCategorie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categorie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorie",
                table: "Categorie",
                column: "IdCategorie");
        }
    }
}
