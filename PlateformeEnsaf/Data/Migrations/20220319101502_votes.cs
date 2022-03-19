using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlateformeEnsaf.Data.Migrations
{
    public partial class votes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Annonce_AnnonceId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "NbrVotes",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VotantId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VoteeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votes_Users_VotantId",
                        column: x => x.VotantId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Votes_Users_VoteeId",
                        column: x => x.VoteeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votes_VotantId",
                table: "Votes",
                column: "VotantId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_VoteeId",
                table: "Votes",
                column: "VoteeId");

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

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.AddColumn<int>(
                name: "NbrVotes",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
