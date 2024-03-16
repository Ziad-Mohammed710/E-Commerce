using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Description for Product 1", "Product 1", 19432m },
                    { 2, "Description for Product 2", "Product 2", 4943m },
                    { 3, "Description for Product 3", "Product 3", 18301m },
                    { 4, "Description for Product 4", "Product 4", 7872m },
                    { 5, "Description for Product 5", "Product 5", 3380m },
                    { 6, "Description for Product 6", "Product 6", 9226m },
                    { 7, "Description for Product 7", "Product 7", 5270m },
                    { 8, "Description for Product 8", "Product 8", 18015m },
                    { 9, "Description for Product 9", "Product 9", 3566m },
                    { 10, "Description for Product 10", "Product 10", 11127m },
                    { 11, "Description for Product 11", "Product 11", 13508m },
                    { 12, "Description for Product 12", "Product 12", 4399m },
                    { 13, "Description for Product 13", "Product 13", 4258m },
                    { 14, "Description for Product 14", "Product 14", 4739m },
                    { 15, "Description for Product 15", "Product 15", 12914m },
                    { 16, "Description for Product 16", "Product 16", 19622m },
                    { 17, "Description for Product 17", "Product 17", 12734m },
                    { 18, "Description for Product 18", "Product 18", 9028m },
                    { 19, "Description for Product 19", "Product 19", 4207m },
                    { 20, "Description for Product 20", "Product 20", 14857m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
