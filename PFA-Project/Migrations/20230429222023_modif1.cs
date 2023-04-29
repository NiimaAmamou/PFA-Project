using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFA_Project.Migrations
{
    public partial class modif1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "familleId",
                table: "Produits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produits_familleId",
                table: "Produits",
                column: "familleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produits_Familles_familleId",
                table: "Produits",
                column: "familleId",
                principalTable: "Familles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produits_Familles_familleId",
                table: "Produits");

            migrationBuilder.DropIndex(
                name: "IX_Produits_familleId",
                table: "Produits");

            migrationBuilder.DropColumn(
                name: "familleId",
                table: "Produits");
        }
    }
}
