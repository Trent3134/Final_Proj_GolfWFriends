using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfWithFriends.Data.Migrations
{
    public partial class DeletedFriends : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Challenges");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GolferA = table.Column<int>(type: "int", nullable: false),
                    GolferB = table.Column<int>(type: "int", nullable: false),
                    GolfersId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Challenges_AspNetUsers_GolfersId",
                        column: x => x.GolfersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_GolfersId",
                table: "Challenges",
                column: "GolfersId");
        }
    }
}
