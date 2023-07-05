using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFA_Project.Migrations
{
    public partial class AjtObjetEmpdansCommande : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpId",
                table: "Commandes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_EmpId",
                table: "Commandes",
                column: "EmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Employees_EmpId",
                table: "Commandes",
                column: "EmpId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Employees_EmpId",
                table: "Commandes");

            migrationBuilder.DropIndex(
                name: "IX_Commandes_EmpId",
                table: "Commandes");

            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "Commandes");
        }
    }
}
