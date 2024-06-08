using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.Persistence.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorName", "CategoryId", "CreatedAt", "Description", "ImagePath", "Title" },
                values: new object[] { "Abernathy - Kris", 1, new DateTime(2024, 6, 8, 19, 8, 9, 901, DateTimeKind.Local).AddTicks(5089), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Rustic Soft Cheese", "Handmade Cotton Chair" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorName", "CategoryId", "CreatedAt", "Description", "ImagePath", "Title" },
                values: new object[] { "Beatty - Kerluke", 1, new DateTime(2024, 6, 8, 19, 8, 9, 901, DateTimeKind.Local).AddTicks(5548), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Handcrafted Cotton Pizza", "Small Granite Keyboard" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorName", "CreatedAt", "Description", "ImagePath", "Title" },
                values: new object[] { "Barton Inc", new DateTime(2024, 6, 8, 19, 8, 9, 901, DateTimeKind.Local).AddTicks(6281), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Licensed Soft Cheese", "Licensed Wooden Computer" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorName", "CreatedAt", "Description", "ImagePath", "Title" },
                values: new object[] { "Veum, Pollich and Schmeler", new DateTime(2024, 6, 8, 19, 8, 9, 901, DateTimeKind.Local).AddTicks(6798), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Intelligent Granite Salad", "Intelligent Granite Keyboard" });

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 8, 19, 8, 9, 898, DateTimeKind.Local).AddTicks(5358));

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2024, 6, 8, 19, 8, 9, 898, DateTimeKind.Local).AddTicks(5469), "Baby" });

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 8, 19, 8, 9, 898, DateTimeKind.Local).AddTicks(5483));

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2024, 6, 8, 19, 8, 9, 898, DateTimeKind.Local).AddTicks(5496), "Tools" });

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2024, 6, 8, 19, 8, 9, 898, DateTimeKind.Local).AddTicks(5507), "Toys" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorName", "CategoryId", "CreatedAt", "Description", "ImagePath", "Title" },
                values: new object[] { "Cremin and Sons", 2, new DateTime(2024, 5, 17, 11, 49, 3, 799, DateTimeKind.Local).AddTicks(7644), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Handmade Frozen Towels", "Rustic Steel Chicken" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorName", "CategoryId", "CreatedAt", "Description", "ImagePath", "Title" },
                values: new object[] { "Willms, Mohr and Swaniawski", 2, new DateTime(2024, 5, 17, 11, 49, 3, 799, DateTimeKind.Local).AddTicks(7878), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Rustic Granite Pants", "Gorgeous Concrete Bacon" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorName", "CreatedAt", "Description", "ImagePath", "Title" },
                values: new object[] { "Emard Inc", new DateTime(2024, 5, 17, 11, 49, 3, 799, DateTimeKind.Local).AddTicks(8016), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Handmade Cotton Gloves", "Sleek Metal Chips" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorName", "CreatedAt", "Description", "ImagePath", "Title" },
                values: new object[] { "Cronin - Hudson", new DateTime(2024, 5, 17, 11, 49, 3, 799, DateTimeKind.Local).AddTicks(8154), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Intelligent Fresh Bacon", "Practical Steel Sausages" });

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 11, 49, 3, 798, DateTimeKind.Local).AddTicks(1884));

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2024, 5, 17, 11, 49, 3, 798, DateTimeKind.Local).AddTicks(1928), "Sports" });

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 11, 49, 3, 798, DateTimeKind.Local).AddTicks(1934));

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2024, 5, 17, 11, 49, 3, 798, DateTimeKind.Local).AddTicks(1939), "Movies" });

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2024, 5, 17, 11, 49, 3, 798, DateTimeKind.Local).AddTicks(1943), "Kids" });
        }
    }
}
