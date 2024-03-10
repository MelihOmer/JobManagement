using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoPlayerLearn.DataAccess.Migrations
{
    public partial class statusAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seen",
                table: "TodoComments");

            migrationBuilder.CreateTable(
                name: "StatusMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusUserId = table.Column<int>(type: "int", nullable: false),
                    StatusContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusMessages_AspNetUsers_StatusUserId",
                        column: x => x.StatusUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StatusMessages_StatusUserId",
                table: "StatusMessages",
                column: "StatusUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatusMessages");

            migrationBuilder.AddColumn<bool>(
                name: "Seen",
                table: "TodoComments",
                type: "bit",
                nullable: false,
                defaultValue: false);

         
        }
    }
}
