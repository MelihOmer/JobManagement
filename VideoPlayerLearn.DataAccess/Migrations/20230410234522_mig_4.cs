using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoPlayerLearn.DataAccess.Migrations
{
    public partial class mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Todos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Todos_DepartmentId",
                table: "Todos",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Departments_DepartmentId",
                table: "Todos",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Departments_DepartmentId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_DepartmentId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Todos");
        }
    }
}
