using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFA_Project.Migrations
{
    public partial class ProduitArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleProduits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    produitIdProduit = table.Column<int>(type: "int", nullable: true),
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    articleIdArticle = table.Column<int>(type: "int", nullable: true),
                    IdArticle = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleProduits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleProduits_Articles_articleIdArticle",
                        column: x => x.articleIdArticle,
                        principalTable: "Articles",
                        principalColumn: "IdArticle");
                    table.ForeignKey(
                        name: "FK_ArticleProduits_Produits_produitIdProduit",
                        column: x => x.produitIdProduit,
                        principalTable: "Produits",
                        principalColumn: "IdProduit");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleProduits_articleIdArticle",
                table: "ArticleProduits",
                column: "articleIdArticle");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleProduits_produitIdProduit",
                table: "ArticleProduits",
                column: "produitIdProduit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleProduits");
        }
    }
}
