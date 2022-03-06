using Microsoft.EntityFrameworkCore.Migrations;

namespace PlateformeEnsaf.Data.Migrations
{
    public partial class Updatingdatabasev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abonnement_Users_Id_Followed_User",
                table: "Abonnement");

            migrationBuilder.DropForeignKey(
                name: "FK_Abonnement_Users_Id_Following_User",
                table: "Abonnement");

            migrationBuilder.DropForeignKey(
                name: "FK_Domaines_Users_ApplicationUserId",
                table: "Domaines");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Filieres_Id_Filiere",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Id_Filiere",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Domaines_ApplicationUserId",
                table: "Domaines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abonnement",
                table: "Abonnement");

            migrationBuilder.DropColumn(
                name: "Id_Filiere",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id_Annonce",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Domaines");

            migrationBuilder.DropColumn(
                name: "Id_Annonce",
                table: "Commentaires");

            migrationBuilder.DropColumn(
                name: "Id_User",
                table: "Commentaires");

            migrationBuilder.DropColumn(
                name: "Id_User",
                table: "Annonce");

            migrationBuilder.RenameTable(
                name: "Abonnement",
                newName: "Abonnements");

            migrationBuilder.RenameIndex(
                name: "IX_Abonnement_Id_Following_User",
                table: "Abonnements",
                newName: "IX_Abonnements_Id_Following_User");

            migrationBuilder.RenameIndex(
                name: "IX_Abonnement_Id_Followed_User",
                table: "Abonnements",
                newName: "IX_Abonnements_Id_Followed_User");

            migrationBuilder.AddColumn<int>(
                name: "FiliereId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abonnements",
                table: "Abonnements",
                column: "Id");

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
                name: "IX_Users_FiliereId",
                table: "Users",
                column: "FiliereId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnonceDomaine_DomainesId",
                table: "AnnonceDomaine",
                column: "DomainesId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserDomaine_UsersId",
                table: "ApplicationUserDomaine",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abonnements_Users_Id_Followed_User",
                table: "Abonnements",
                column: "Id_Followed_User",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Abonnements_Users_Id_Following_User",
                table: "Abonnements",
                column: "Id_Following_User",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Filieres_FiliereId",
                table: "Users",
                column: "FiliereId",
                principalTable: "Filieres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abonnements_Users_Id_Followed_User",
                table: "Abonnements");

            migrationBuilder.DropForeignKey(
                name: "FK_Abonnements_Users_Id_Following_User",
                table: "Abonnements");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Filieres_FiliereId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AnnonceDomaine");

            migrationBuilder.DropTable(
                name: "ApplicationUserDomaine");

            migrationBuilder.DropIndex(
                name: "IX_Users_FiliereId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abonnements",
                table: "Abonnements");

            migrationBuilder.DropColumn(
                name: "FiliereId",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Abonnements",
                newName: "Abonnement");

            migrationBuilder.RenameIndex(
                name: "IX_Abonnements_Id_Following_User",
                table: "Abonnement",
                newName: "IX_Abonnement_Id_Following_User");

            migrationBuilder.RenameIndex(
                name: "IX_Abonnements_Id_Followed_User",
                table: "Abonnement",
                newName: "IX_Abonnement_Id_Followed_User");

            migrationBuilder.AddColumn<int>(
                name: "Id_Filiere",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Annonce",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Domaines",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_Annonce",
                table: "Commentaires",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Id_User",
                table: "Commentaires",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Id_User",
                table: "Annonce",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abonnement",
                table: "Abonnement",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id_Filiere",
                table: "Users",
                column: "Id_Filiere");

            migrationBuilder.CreateIndex(
                name: "IX_Domaines_ApplicationUserId",
                table: "Domaines",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abonnement_Users_Id_Followed_User",
                table: "Abonnement",
                column: "Id_Followed_User",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Abonnement_Users_Id_Following_User",
                table: "Abonnement",
                column: "Id_Following_User",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Domaines_Users_ApplicationUserId",
                table: "Domaines",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Filieres_Id_Filiere",
                table: "Users",
                column: "Id_Filiere",
                principalTable: "Filieres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
