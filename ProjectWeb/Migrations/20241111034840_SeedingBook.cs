using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectWeb.Migrations
{
    /// <inheritdoc />
    public partial class SeedingBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Jon Krakauer", 1, "An adventurous journey through nature.", null, 15.99, "Into the Wild" },
                    { 2, "Jane Austen", 2, "A romantic novel of manners.", null, 12.99, "Pride and Prejudice" },
                    { 3, "Bram Stoker", 3, "A horror classic that defines vampires.", null, 10.99, "Dracula" },
                    { 4, "Frank Herbert", 4, "A science fiction epic.", null, 18.989999999999998, "Dune" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
