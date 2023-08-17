using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemirorenProject.API.Migrations
{
    public partial class idToNewsReadTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "NewsRead",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 8, 10, 16, 57, 57, 551, DateTimeKind.Local).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 8, 10, 16, 57, 57, 551, DateTimeKind.Local).AddTicks(3391));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 8, 10, 16, 57, 57, 551, DateTimeKind.Local).AddTicks(3392));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 8, 10, 16, 57, 57, 551, DateTimeKind.Local).AddTicks(3393));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "NewsRead");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 8, 10, 5, 33, 35, 631, DateTimeKind.Local).AddTicks(8616));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 8, 10, 5, 33, 35, 631, DateTimeKind.Local).AddTicks(8632));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 8, 10, 5, 33, 35, 631, DateTimeKind.Local).AddTicks(8633));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 8, 10, 5, 33, 35, 631, DateTimeKind.Local).AddTicks(8634));
        }
    }
}
