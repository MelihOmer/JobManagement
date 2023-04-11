using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoPlayerLearn.DataAccess.Migrations
{
    public partial class mig_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TodoStatusId",
                table: "Todos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Todos_TodoStatusId",
                table: "Todos",
                column: "TodoStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_TodoStatuses_TodoStatusId",
                table: "Todos",
                column: "TodoStatusId",
                principalTable: "TodoStatuses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_TodoStatuses_TodoStatusId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_TodoStatusId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "TodoStatusId",
                table: "Todos");
        }
    }
}
