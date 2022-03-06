using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlateformeEnsaf.Data.Migrations
{
    public partial class Updatingdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abonnement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Following_User = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id_Followed_User = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonnement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abonnement_Users_Id_Followed_User",
                        column: x => x.Id_Followed_User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Abonnement_Users_Id_Following_User",
                        column: x => x.Id_Following_User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Annonce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Id_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DatePublication = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<int>(type: "int", nullable: false),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categorie = table.Column<int>(type: "int", nullable: true),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Entreprise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annonce", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Annonce_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Domaines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domaines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Domaines_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Commentaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id_Annonce = table.Column<int>(type: "int", nullable: false),
                    AnnonceId = table.Column<int>(type: "int", nullable: true),
                    Contenu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DatePublication = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commentaires_Annonce_AnnonceId",
                        column: x => x.AnnonceId,
                        principalTable: "Annonce",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commentaires_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Annonce = table.Column<int>(type: "int", nullable: false),
                    AnnonceId = table.Column<int>(type: "int", nullable: true),
                    Contenu = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Annonce_AnnonceId",
                        column: x => x.AnnonceId,
                        principalTable: "Annonce",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abonnement_Id_Followed_User",
                table: "Abonnement",
                column: "Id_Followed_User");

            migrationBuilder.CreateIndex(
                name: "IX_Abonnement_Id_Following_User",
                table: "Abonnement",
                column: "Id_Following_User");

            migrationBuilder.CreateIndex(
                name: "IX_Annonce_UserId",
                table: "Annonce",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_AnnonceId",
                table: "Commentaires",
                column: "AnnonceId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_UserId",
                table: "Commentaires",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Domaines_ApplicationUserId",
                table: "Domaines",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AnnonceId",
                table: "Images",
                column: "AnnonceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abonnement");

            migrationBuilder.DropTable(
                name: "Commentaires");

            migrationBuilder.DropTable(
                name: "Domaines");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Annonce");
        }
    }
}
