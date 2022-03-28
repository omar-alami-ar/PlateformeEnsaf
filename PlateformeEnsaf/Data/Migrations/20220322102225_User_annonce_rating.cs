using Microsoft.EntityFrameworkCore.Migrations;

namespace PlateformeEnsaf.Data.Migrations
{
    public partial class User_annonce_rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User_Annonce_Rating",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AnnonceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Annonce_Rating", x => new { x.UserId, x.AnnonceId });
                    table.ForeignKey(
                        name: "FK_User_Annonce_Rating_Annonce_AnnonceId",
                        column: x => x.AnnonceId,
                        principalTable: "Annonce",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Annonce_Rating_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Annonce_Rating_AnnonceId",
                table: "User_Annonce_Rating",
                column: "AnnonceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Annonce_Rating");
        }
    }
}
