using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfWithFriends.Data.Migrations
{
    public partial class ChallengesP2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ChallengeId",
                table: "Challenge",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Challenge2Id",
                table: "Challenge",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Challenge_Challenge2Id",
                table: "Challenge",
                column: "Challenge2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Challenge_ChallengeId",
                table: "Challenge",
                column: "ChallengeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenge_AspNetUsers_Challenge2Id",
                table: "Challenge",
                column: "Challenge2Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenge_AspNetUsers_ChallengeId",
                table: "Challenge",
                column: "ChallengeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challenge_AspNetUsers_Challenge2Id",
                table: "Challenge");

            migrationBuilder.DropForeignKey(
                name: "FK_Challenge_AspNetUsers_ChallengeId",
                table: "Challenge");

            migrationBuilder.DropIndex(
                name: "IX_Challenge_Challenge2Id",
                table: "Challenge");

            migrationBuilder.DropIndex(
                name: "IX_Challenge_ChallengeId",
                table: "Challenge");

            migrationBuilder.AlterColumn<string>(
                name: "ChallengeId",
                table: "Challenge",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Challenge2Id",
                table: "Challenge",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
