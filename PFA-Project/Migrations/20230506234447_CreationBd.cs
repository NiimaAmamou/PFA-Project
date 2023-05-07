using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFA_Project.Migrations
{
    public partial class CreationBd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCategorie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibelleCategorie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCategorie);
                });

            migrationBuilder.CreateTable(
                name: "Familles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Couleur = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    N_Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Statut = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumTable = table.Column<int>(type: "int", nullable: false),
                    Capacite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EtatTable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    IdArticle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefArticle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibelleArticle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QteStock = table.Column<int>(type: "int", nullable: false),
                    Unite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCat = table.Column<int>(type: "int", nullable: true),
                    CategorieIdCategorie = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.IdArticle);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategorieIdCategorie",
                        column: x => x.CategorieIdCategorie,
                        principalTable: "Categories",
                        principalColumn: "IdCategorie");
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibelleProduit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prix = table.Column<double>(type: "float", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    familleId = table.Column<int>(type: "int", nullable: true),
                    IdFamille = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.IdProduit);
                    table.ForeignKey(
                        name: "FK_Produits_Familles_familleId",
                        column: x => x.familleId,
                        principalTable: "Familles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fournitures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdArticle = table.Column<int>(type: "int", nullable: false),
                    IdFournisseur = table.Column<int>(type: "int", nullable: false),
                    Qte = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournitures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fournitures_Articles_IdArticle",
                        column: x => x.IdArticle,
                        principalTable: "Articles",
                        principalColumn: "IdArticle",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fournitures_Fournisseurs_IdFournisseur",
                        column: x => x.IdFournisseur,
                        principalTable: "Fournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategorieIdCategorie",
                table: "Articles",
                column: "CategorieIdCategorie");

            migrationBuilder.CreateIndex(
                name: "IX_Fournitures_IdArticle",
                table: "Fournitures",
                column: "IdArticle");

            migrationBuilder.CreateIndex(
                name: "IX_Fournitures_IdFournisseur",
                table: "Fournitures",
                column: "IdFournisseur");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_familleId",
                table: "Produits",
                column: "familleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleProduits");

            migrationBuilder.DropTable(
                name: "Fournitures");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Fournisseurs");

            migrationBuilder.DropTable(
                name: "Familles");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
