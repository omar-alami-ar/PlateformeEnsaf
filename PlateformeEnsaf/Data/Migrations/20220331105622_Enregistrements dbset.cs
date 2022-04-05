using Microsoft.EntityFrameworkCore.Migrations;

namespace PlateformeEnsaf.Data.Migrations
{
    public partial class Enregistrementsdbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enregistrement_Annonce_AnnonceId",
                table: "Enregistrement");

            migrationBuilder.DropForeignKey(
                name: "FK_Enregistrement_Users_UserId",
                table: "Enregistrement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enregistrement",
                table: "Enregistrement");

            migrationBuilder.RenameTable(
                name: "Enregistrement",
                newName: "Enregistrements");

            migrationBuilder.RenameIndex(
                name: "IX_Enregistrement_AnnonceId",
                table: "Enregistrements",
                newName: "IX_Enregistrements_AnnonceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enregistrements",
                table: "Enregistrements",
                columns: new[] { "UserId", "AnnonceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Enregistrements_Annonce_AnnonceId",
                table: "Enregistrements",
                column: "AnnonceId",
                principalTable: "Annonce",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enregistrements_Users_UserId",
                table: "Enregistrements",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enregistrements_Annonce_AnnonceId",
                table: "Enregistrements");

            migrationBuilder.DropForeignKey(
                name: "FK_Enregistrements_Users_UserId",
                table: "Enregistrements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enregistrements",
                table: "Enregistrements");

            migrationBuilder.RenameTable(
                name: "Enregistrements",
                newName: "Enregistrement");

            migrationBuilder.RenameIndex(
                name: "IX_Enregistrements_AnnonceId",
                table: "Enregistrement",
                newName: "IX_Enregistrement_AnnonceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enregistrement",
                table: "Enregistrement",
                columns: new[] { "UserId", "AnnonceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Enregistrement_Annonce_AnnonceId",
                table: "Enregistrement",
                column: "AnnonceId",
                principalTable: "Annonce",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enregistrement_Users_UserId",
                table: "Enregistrement",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
