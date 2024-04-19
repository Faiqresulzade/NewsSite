using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.Persistence.Migrations
{
    public partial class AddedNewsAndNewsCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReadCount = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_NewsCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "NewsCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "NewsCategories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 19, 23, 59, 54, 433, DateTimeKind.Local).AddTicks(7775), false, "Music" },
                    { 2, new DateTime(2024, 4, 19, 23, 59, 54, 433, DateTimeKind.Local).AddTicks(7842), false, "Toys" },
                    { 3, new DateTime(2024, 4, 19, 23, 59, 54, 433, DateTimeKind.Local).AddTicks(7852), false, "Music" },
                    { 4, new DateTime(2024, 4, 19, 23, 59, 54, 433, DateTimeKind.Local).AddTicks(7861), false, "Movies" },
                    { 5, new DateTime(2024, 4, 19, 23, 59, 54, 433, DateTimeKind.Local).AddTicks(7870), false, "Kids" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "AuthorName", "CategoryId", "CreatedAt", "Description", "ImagePath", "IsDeleted", "ReadCount", "Title" },
                values: new object[,]
                {
                    { 1, "Braun, Hackett and Blanda", 1, new DateTime(2024, 4, 19, 23, 59, 54, 436, DateTimeKind.Local).AddTicks(3285), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Awesome Wooden Chicken", false, 0, "Handmade Steel Towels" },
                    { 2, "Langworth and Sons", 2, new DateTime(2024, 4, 19, 23, 59, 54, 436, DateTimeKind.Local).AddTicks(3570), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Unbranded Wooden Sausages", false, 5, "Ergonomic Cotton Towels" },
                    { 3, "Altenwerth - Haag", 1, new DateTime(2024, 4, 19, 23, 59, 54, 436, DateTimeKind.Local).AddTicks(3888), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Unbranded Soft Gloves", false, 10, "Sleek Wooden Chair" },
                    { 4, "Auer LLC", 2, new DateTime(2024, 4, 19, 23, 59, 54, 436, DateTimeKind.Local).AddTicks(4100), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Intelligent Metal Towels", false, 15, "Sleek Metal Salad" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoryId",
                table: "News",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "NewsCategories");
        }
    }
}
