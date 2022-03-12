using Microsoft.EntityFrameworkCore.Migrations;

namespace PlateformeEnsaf.Data.Migrations
{
    public partial class lastone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnonceDomaine");

            migrationBuilder.DropTable(
                name: "ApplicationUserDomaine");

            migrationBuilder.CreateTable(
                name: "Annonce_Domaines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnnonceId = table.Column<int>(type: "int", nullable: false),
                    DomaineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annonce_Domaines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Annonce_Domaines_Annonce_AnnonceId",
                        column: x => x.AnnonceId,
                        principalTable: "Annonce",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Annonce_Domaines_Domaines_DomaineId",
                        column: x => x.DomaineId,
                        principalTable: "Domaines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_Domaines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DomaineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_Domaines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_Domaines_Domaines_DomaineId",
                        column: x => x.DomaineId,
                        principalTable: "Domaines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_Domaines_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Annonce_Domaines_AnnonceId",
                table: "Annonce_Domaines",
                column: "AnnonceId");

            migrationBuilder.CreateIndex(
                name: "IX_Annonce_Domaines_DomaineId",
                table: "Annonce_Domaines",
                column: "DomaineId");

            migrationBuilder.CreateIndex(
                name: "IX_user_Domaines_DomaineId",
                table: "user_Domaines",
                column: "DomaineId");

            migrationBuilder.CreateIndex(
                name: "IX_user_Domaines_UserId",
                table: "user_Domaines",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Annonce_Domaines");

            migrationBuilder.DropTable(
                name: "user_Domaines");

            migrationBuilder.CreateTable(
                name: "AnnonceDomaine",
                columns: table => new
                {
                    AnnoncesId = table.Column<int>(type: "int", nullable: false),
                    DomainesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnonceDomaine", x => new { x.AnnoncesId, x.DomainesId });
                    table.ForeignKey(
                        name: "FK_AnnonceDomaine_Annonce_AnnoncesId",
                        column: x => x.AnnoncesId,
                        principalTable: "Annonce",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnnonceDomaine_Domaines_DomainesId",
                        column: x => x.DomainesId,
                        principalTable: "Domaines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserDomaine",
                columns: table => new
                {
                    InteretsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserDomaine", x => new { x.InteretsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserDomaine_Domaines_InteretsId",
                        column: x => x.InteretsId,
                        principalTable: "Domaines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserDomaine_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnonceDomaine_DomainesId",
                table: "AnnonceDomaine",
                column: "DomainesId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserDomaine_UsersId",
                table: "ApplicationUserDomaine",
                column: "UsersId");
        }
    }
}
