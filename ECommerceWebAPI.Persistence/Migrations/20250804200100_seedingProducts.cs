using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceWebAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seedingProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsArchived", "IsDeleted", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 4, 20, 0, 59, 985, DateTimeKind.Utc).AddTicks(6503), "Mouse with USB", true, false, false, "Mouse", 29.989999999999998, 150, null },
                    { 2, new DateTime(2025, 8, 4, 20, 0, 59, 985, DateTimeKind.Utc).AddTicks(6505), "Keyboard with USB", true, false, false, "Keyboard", 69.989999999999995, 100, null },
                    { 3, new DateTime(2025, 8, 4, 20, 0, 59, 985, DateTimeKind.Utc).AddTicks(6507), "Full HD IPS monitor", true, false, false, "Monitor", 199.99000000000001, 50, null },
                    { 4, new DateTime(2025, 8, 4, 20, 0, 59, 985, DateTimeKind.Utc).AddTicks(6509), "No Description", true, false, false, "IPhone 15", 39.990000000000002, 200, null },
                    { 5, new DateTime(2025, 8, 4, 20, 0, 59, 985, DateTimeKind.Utc).AddTicks(6511), "Asus Laptop", true, false, false, "Laptop", 24.989999999999998, 80, null }
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
        }
    }
}
