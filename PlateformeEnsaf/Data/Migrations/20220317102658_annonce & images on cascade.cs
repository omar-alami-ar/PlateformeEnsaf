using Microsoft.EntityFrameworkCore.Migrations;

namespace PlateformeEnsaf.Data.Migrations
{
    public partial class annonceimagesoncascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Annonce_AnnonceId",
                table: "Images");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Annonce_AnnonceId",
                table: "Images",
                column: "AnnonceId",
                principalTable: "Annonce",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Annonce_AnnonceId",
                table: "Images");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Annonce_AnnonceId",
                table: "Images",
                column: "AnnonceId",
                principalTable: "Annonce",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
