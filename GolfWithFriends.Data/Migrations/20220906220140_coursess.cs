using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfWithFriends.Data.Migrations
{
    public partial class coursess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstAndLastName",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstAndLastName",
                table: "Course");
        }
    }
}
