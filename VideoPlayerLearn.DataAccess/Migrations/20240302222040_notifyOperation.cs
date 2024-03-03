using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoPlayerLearn.DataAccess.Migrations
{
    public partial class notifyOperation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Seen",
                table: "TodoComments",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "b7b69912-b85b-4fc1-b60c-182c0d61d7f8", "Egitim" });

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

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Decription",
                value: "Bilgi İşlem Donanım");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seen",
                table: "TodoComments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "b8a8f58b-f808-429e-8e12-0b9901893413");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e4077929-1238-4078-8778-1e790d0400da");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "94cbe905-14fe-4670-94bc-e32141c7579b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "e153a67a-5041-48c7-a815-1d56f79e7cbb", "Eğitim" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b089d3a0-f949-4ca3-be77-3fd4330da797", "AQAAAAEAACcQAAAAEM32uJ2jb6lqGwSLzIO8lu6dh08sUttpHkdzkO1WP+fm0xvRU2HJ9rxNB+NDO6otNw==", "f3f0f786-04f5-4a89-855e-3a0cc2375bdc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d003db4-862e-446b-bdd9-8bb40e47f896", "AQAAAAEAACcQAAAAEMAZm1tmXbaT8WU7f8icTKbpuBO5bGn7vczE9uy9E7bXXL/6KsUgvkCWoHZRO/ECgg==", "14e2624f-5666-48df-9779-198dd8cfa28c" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Decription",
                value: "Bilgi İşlem Donamım");
        }
    }
}
