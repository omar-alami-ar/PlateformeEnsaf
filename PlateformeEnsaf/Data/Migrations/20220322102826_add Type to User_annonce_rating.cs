using Microsoft.EntityFrameworkCore.Migrations;

namespace PlateformeEnsaf.Data.Migrations
{
    public partial class addTypetoUser_annonce_rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "User_Annonce_Rating",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "User_Annonce_Rating");
        }
    }
}
