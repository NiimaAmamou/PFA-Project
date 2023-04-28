using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFA_Project.Migrations
{
    public partial class Prod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProduitArticles_Articles_articleIdArticle",
                table: "ProduitArticles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProduitArticles_Produit_produitIdProduit",
                table: "ProduitArticles");

            migrationBuilder.DropColumn(
                name: "IdProduitArticle",
                table: "Produit");

            migrationBuilder.AlterColumn<int>(
                name: "produitIdProduit",
                table: "ProduitArticles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "articleIdArticle",
                table: "ProduitArticles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Quantite",
                table: "ProduitArticles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProduitArticles_Articles_articleIdArticle",
                table: "ProduitArticles",
                column: "articleIdArticle",
                principalTable: "Articles",
                principalColumn: "IdArticle");

            migrationBuilder.AddForeignKey(
                name: "FK_ProduitArticles_Produit_produitIdProduit",
                table: "ProduitArticles",
                column: "produitIdProduit",
                principalTable: "Produit",
                principalColumn: "IdProduit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProduitArticles_Articles_articleIdArticle",
                table: "ProduitArticles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProduitArticles_Produit_produitIdProduit",
                table: "ProduitArticles");

            migrationBuilder.AlterColumn<int>(
                name: "produitIdProduit",
                table: "ProduitArticles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "articleIdArticle",
                table: "ProduitArticles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantite",
                table: "ProduitArticles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdProduitArticle",
                table: "Produit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ProduitArticles_Articles_articleIdArticle",
                table: "ProduitArticles",
                column: "articleIdArticle",
                principalTable: "Articles",
                principalColumn: "IdArticle",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProduitArticles_Produit_produitIdProduit",
                table: "ProduitArticles",
                column: "produitIdProduit",
                principalTable: "Produit",
                principalColumn: "IdProduit",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
