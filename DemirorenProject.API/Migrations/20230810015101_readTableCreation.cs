using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemirorenProject.API.Migrations
{
    public partial class readTableCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsRead",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NewsID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsRead", x => x.UserID);
                });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 8, 10, 4, 51, 1, 376, DateTimeKind.Local).AddTicks(5020));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 8, 10, 4, 51, 1, 376, DateTimeKind.Local).AddTicks(5032));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 8, 10, 4, 51, 1, 376, DateTimeKind.Local).AddTicks(5033));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 8, 10, 4, 51, 1, 376, DateTimeKind.Local).AddTicks(5034));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsRead");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 8, 10, 4, 7, 2, 952, DateTimeKind.Local).AddTicks(4058));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 8, 10, 4, 7, 2, 952, DateTimeKind.Local).AddTicks(4071));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 8, 10, 4, 7, 2, 952, DateTimeKind.Local).AddTicks(4072));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 8, 10, 4, 7, 2, 952, DateTimeKind.Local).AddTicks(4074));
        }
    }
}
