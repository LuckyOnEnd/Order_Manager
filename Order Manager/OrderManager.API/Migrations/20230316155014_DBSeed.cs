using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderManager.API.Migrations
{
    /// <inheritdoc />
    public partial class DBSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ClientName",
                table: "Orders",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "OrderLines",
                columns: new[] { "Id", "OrderID", "Price", "Product" },
                values: new object[,]
                {
                    { 1, 1, 262.49m, "Battery" },
                    { 2, 1, 262.49m, "Battery" },
                    { 3, 1, 262.49m, "Battery" },
                    { 4, 1, 262.49m, "Battery" },
                    { 5, 2, 499.99m, "Smart Watch" },
                    { 6, 3, 300.00m, "Wazon dla kwitów" },
                    { 7, 3, 300.99m, "Wazon dla kwitów" },
                    { 8, 4, 299.99m, "Zara - Kurtka Pikowana" },
                    { 9, 5, 299.99m, "Mysz LOGITECH G502 Hero" },
                    { 10, 5, 299.99m, "Mysz LOGITECH G102" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AdditionalInfo", "Address", "City", "ClientName", "CreateDate", "OrderPrice", "Status" },
                values: new object[,]
                {
                    { 1, "Deliver only in extra hard packaging", "Bliżniąt 12/a", "Poznań", "Viacheslav", new DateTime(2023, 1, 23, 10, 14, 57, 26, DateTimeKind.Unspecified), 1049.96m, "Delivery" },
                    { 2, "shipping cost is calculated separately", "Szamarzewskiego 23", "Wroclaw", "LuckyOnEnd", new DateTime(2023, 2, 4, 8, 46, 34, 18, DateTimeKind.Unspecified), 499.99m, "Delivery" },
                    { 3, " ", "Bliżniąt 12/a", "Poznań", "KaterinaMaslova", new DateTime(2023, 1, 23, 10, 14, 57, 26, DateTimeKind.Unspecified), 600.00m, "Delivery" },
                    { 4, " ", "Slowackiego 37", "Poznań", "EhorDev", new DateTime(2023, 1, 23, 10, 14, 57, 26, DateTimeKind.Unspecified), 299.00m, "Delivery" },
                    { 5, " ", "", "Gdańsk", "Sławek274", new DateTime(2023, 1, 23, 10, 14, 57, 26, DateTimeKind.Unspecified), 356.00m, "Delivery" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderLines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderLines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderLines",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderLines",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderLines",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderLines",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderLines",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderLines",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderLines",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderLines",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "ClientName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);
        }
    }
}
