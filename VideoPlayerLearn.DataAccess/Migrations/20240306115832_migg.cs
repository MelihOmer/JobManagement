using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoPlayerLearn.DataAccess.Migrations
{
    public partial class migg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
 

            migrationBuilder.CreateTable(
                name: "ClientNotification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TodoId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    AppUserSeen = table.Column<bool>(type: "bit", nullable: false),
                    AssignedToUserId = table.Column<int>(type: "int", nullable: true),
                    AssignedToUserSeen = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientNotification_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClientNotification_AspNetUsers_AssignedToUserId",
                        column: x => x.AssignedToUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete:ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClientNotification_Todos_TodoId",
                        column: x => x.TodoId,
                        principalTable: "Todos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropTable(
                name: "ClientNotification");

        }
    }
}
