using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfWithFriends.Data.Migrations
{
    public partial class Challenges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Challenge2Id",
                table: "GolferFriends");

            migrationBuilder.DropColumn(
                name: "ChallengeId",
                table: "GolferFriends");

            migrationBuilder.CreateTable(
                name: "Challenge",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChallengeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Challenge2Id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenge", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Challenge");

            migrationBuilder.AddColumn<string>(
                name: "Challenge2Id",
                table: "GolferFriends",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChallengeId",
                table: "GolferFriends",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
