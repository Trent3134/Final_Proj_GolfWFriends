using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfWithFriends.Data.Migrations
{
    public partial class UserSetUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DegreeWedge",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DegreeWedge2",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Driver",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EightIron",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FiveIron",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FiveWood",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FourIron",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NineIron",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OneIron",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PitchingWedge",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SevenIron",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SixIron",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThreeIron",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThreeWood",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TwoIron",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DegreeWedge",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DegreeWedge2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Driver",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EightIron",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FiveIron",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FiveWood",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FourIron",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NineIron",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OneIron",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PitchingWedge",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SevenIron",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SixIron",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ThreeIron",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ThreeWood",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TwoIron",
                table: "AspNetUsers");
        }
    }
}
