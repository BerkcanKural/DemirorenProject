using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemirorenProject.API.Migrations
{
    public partial class DATABASECREATİON : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "sports" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "science" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "politics" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "CategoryId", "Content", "Date", "Title" },
                values: new object[] { 1, 1, "This is the content for sports news", new DateTime(2023, 7, 28, 18, 54, 49, 502, DateTimeKind.Local).AddTicks(1389), "Test" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "CategoryId", "Content", "Date", "Title" },
                values: new object[] { 2, 2, "This is the content for science news", new DateTime(2023, 7, 28, 18, 54, 49, 502, DateTimeKind.Local).AddTicks(1402), "Test2" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "CategoryId", "Content", "Date", "Title" },
                values: new object[] { 3, 3, "This is the content for politics news", new DateTime(2023, 7, 28, 18, 54, 49, 502, DateTimeKind.Local).AddTicks(1402), "Test3" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "CategoryId", "Content", "Date", "Title" },
                values: new object[] { 4, 3, "This is the content for another politics news", new DateTime(2023, 7, 28, 18, 54, 49, 502, DateTimeKind.Local).AddTicks(1404), "Test4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
