using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoPlayerLearn.DataAccess.Migrations
{
    public partial class NotifyTableIni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TodoId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    AppUserSeen = table.Column<bool>(type: "bit", nullable: false),
                    AssignedToUserId = table.Column<int>(type: "int", nullable: false),
                    AssignedToUserSeen = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientNotifications_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClientNotifications_AspNetUsers_AssignedToUserId",
                        column: x => x.AssignedToUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClientNotifications_Todos_TodoId",
                        column: x => x.TodoId,
                        principalTable: "Todos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "13704996-c539-42d6-a711-fc9ac589cb42");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "49a04014-fd5f-4315-977a-ad9db02ef880");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "58a45a79-c5f8-4eb8-898b-13efdf819f3a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "9061f7ec-9589-4510-9b26-04d8684114c0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a1fb082-8d29-4eb9-92b2-8be9eae2f58e", "AQAAAAEAACcQAAAAEHOKoxPCN+RL0iV7Gm4jwOIiC3naMFJvQA2MumIH2MiT6FmoGmPtslpVs8maXvmY4A==", "c2bfac16-1162-44eb-bf86-f7893c099e95" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30a0cbe8-8191-482d-8974-01ec18523aa1", "AQAAAAEAACcQAAAAENQPoQkzNwD+56pj0seguJyaBFG6N1p10XW97FAiB+Mr7jM8IVsIWVgSzpE2GjNdBg==", "8f70570a-1481-4b57-b8ec-7309589c3623" });

            migrationBuilder.CreateIndex(
                name: "IX_ClientNotifications_AppUserId",
                table: "ClientNotifications",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientNotifications_AssignedToUserId",
                table: "ClientNotifications",
                column: "AssignedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientNotifications_TodoId",
                table: "ClientNotifications",
                column: "TodoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientNotifications");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "2dbd491f-fdd7-41fe-aa0a-28f75ad91596");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0d169753-c9d4-4a44-a18b-4df4e29f211c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "a8e0e11a-532e-435d-8d30-45eacffe3354");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "b7b69912-b85b-4fc1-b60c-182c0d61d7f8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a4a9cdc-c6ab-40b7-8f46-d53f639e0c71", "AQAAAAEAACcQAAAAEML0YDI2gpqExIgjnEu/ARyWZKjd3Q5heob9SG3mPGgv72bTMiaTvxIhpVwiMtIx/w==", "39060cfd-0f8a-470c-87dd-8673421d642d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f32a6a8-09cb-4c77-a812-927b479b579f", "AQAAAAEAACcQAAAAEOb7hfV5dmrGn2YXdh2IF8SCDqT03wofk/PlcBTtuHSW7gLkh1plvj7D8lP4sp3yCw==", "6c1b3202-bf97-4465-b5c8-fdf083255812" });
        }
    }
}
