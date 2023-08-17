using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemirorenProject.API.Migrations
{
    public partial class idToNewsReadTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 8, 10, 17, 22, 33, 1, DateTimeKind.Local).AddTicks(5612));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 8, 10, 17, 22, 33, 1, DateTimeKind.Local).AddTicks(5626));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 8, 10, 17, 22, 33, 1, DateTimeKind.Local).AddTicks(5627));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 8, 10, 17, 22, 33, 1, DateTimeKind.Local).AddTicks(5628));

            migrationBuilder.InsertData(
                table: "NewsRead",
                columns: new[] { "Id", "NewsID", "UserID" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "NewsRead",
                columns: new[] { "Id", "NewsID", "UserID" },
                values: new object[] { 2, 2, 2 });

            migrationBuilder.InsertData(
                table: "NewsRead",
                columns: new[] { "Id", "NewsID", "UserID" },
                values: new object[] { 3, 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NewsRead",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NewsRead",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NewsRead",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 8, 10, 17, 2, 6, 768, DateTimeKind.Local).AddTicks(3078));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 8, 10, 17, 2, 6, 768, DateTimeKind.Local).AddTicks(3090));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 8, 10, 17, 2, 6, 768, DateTimeKind.Local).AddTicks(3091));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 8, 10, 17, 2, 6, 768, DateTimeKind.Local).AddTicks(3092));
        }
    }
}
