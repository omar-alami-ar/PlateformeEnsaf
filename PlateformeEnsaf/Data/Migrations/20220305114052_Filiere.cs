using Microsoft.EntityFrameworkCore.Migrations;

namespace PlateformeEnsaf.Data.Migrations
{
    public partial class Filiere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Filiere_Id_Filiere",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filiere",
                table: "Filiere");

            migrationBuilder.RenameTable(
                name: "Filiere",
                newName: "Filieres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filieres",
                table: "Filieres",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Filieres_Id_Filiere",
                table: "Users",
                column: "Id_Filiere",
                principalTable: "Filieres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Filieres_Id_Filiere",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filieres",
                table: "Filieres");

            migrationBuilder.RenameTable(
                name: "Filieres",
                newName: "Filiere");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filiere",
                table: "Filiere",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Filiere_Id_Filiere",
                table: "Users",
                column: "Id_Filiere",
                principalTable: "Filiere",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
