using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFA_Project.Migrations
{
    public partial class modifFamille : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Familles");

            migrationBuilder.AddColumn<string>(
                name: "Couleur",
                table: "Familles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Couleur",
                table: "Familles");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Familles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
