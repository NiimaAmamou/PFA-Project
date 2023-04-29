using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFA_Project.Migrations
{
    public partial class ww : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProduitArticles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProduitArticles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    articleIdArticle = table.Column<int>(type: "int", nullable: true),
                    produitIdProduit = table.Column<int>(type: "int", nullable: true),
                    IdArticle = table.Column<int>(type: "int", nullable: false),
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduitArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProduitArticles_Articles_articleIdArticle",
                        column: x => x.articleIdArticle,
                        principalTable: "Articles",
                        principalColumn: "IdArticle");
                    table.ForeignKey(
                        name: "FK_ProduitArticles_Produit_produitIdProduit",
                        column: x => x.produitIdProduit,
                        principalTable: "Produit",
                        principalColumn: "IdProduit");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProduitArticles_articleIdArticle",
                table: "ProduitArticles",
                column: "articleIdArticle");

            migrationBuilder.CreateIndex(
                name: "IX_ProduitArticles_produitIdProduit",
                table: "ProduitArticles",
                column: "produitIdProduit");
        }
    }
}
