using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFA_Project.Migrations
{
    public partial class crudCat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fournitures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleIdArticle = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournitures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fournitures_Articles_ArticleIdArticle",
                        column: x => x.ArticleIdArticle,
                        principalTable: "Articles",
                        principalColumn: "IdArticle");
                });

            migrationBuilder.CreateTable(
                name: "ProduitArticles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    produitIdProduit = table.Column<int>(type: "int", nullable: false),
                    articleIdArticle = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduitArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProduitArticles_Articles_articleIdArticle",
                        column: x => x.articleIdArticle,
                        principalTable: "Articles",
                        principalColumn: "IdArticle",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProduitArticles_Produit_produitIdProduit",
                        column: x => x.produitIdProduit,
                        principalTable: "Produit",
                        principalColumn: "IdProduit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fournitures_ArticleIdArticle",
                table: "Fournitures",
                column: "ArticleIdArticle");

            migrationBuilder.CreateIndex(
                name: "IX_ProduitArticles_articleIdArticle",
                table: "ProduitArticles",
                column: "articleIdArticle");

            migrationBuilder.CreateIndex(
                name: "IX_ProduitArticles_produitIdProduit",
                table: "ProduitArticles",
                column: "produitIdProduit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fournitures");

            migrationBuilder.DropTable(
                name: "ProduitArticles");
        }
    }
}
