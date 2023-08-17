using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemirorenProject.API.Migrations
{
    public partial class k : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsRead",
                table: "NewsRead");

            migrationBuilder.AlterColumn<int>(
                name: "NewsID",
                table: "NewsRead",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "NewsRead",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsRead",
                table: "NewsRead",
                column: "NewsID");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 8, 10, 5, 14, 48, 456, DateTimeKind.Local).AddTicks(328));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 8, 10, 5, 14, 48, 456, DateTimeKind.Local).AddTicks(341));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 8, 10, 5, 14, 48, 456, DateTimeKind.Local).AddTicks(342));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 8, 10, 5, 14, 48, 456, DateTimeKind.Local).AddTicks(343));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsRead",
                table: "NewsRead");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "NewsRead",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "NewsID",
                table: "NewsRead",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsRead",
                table: "NewsRead",
                column: "UserID");

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
    }
}
