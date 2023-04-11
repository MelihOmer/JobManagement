using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoPlayerLearn.DataAccess.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "TodoComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TodoComments_AppUserId",
                table: "TodoComments",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoComments_AspNetUsers_AppUserId",
                table: "TodoComments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoComments_AspNetUsers_AppUserId",
                table: "TodoComments");

            migrationBuilder.DropIndex(
                name: "IX_TodoComments_AppUserId",
                table: "TodoComments");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "TodoComments");
        }
    }
}
