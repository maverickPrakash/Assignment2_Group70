using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp1.Migrations
{
    public partial class initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_Username",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Username",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "Email", "Password", "UserType" },
                values: new object[] { "buyer", "buer@gmail.com", "buyer", "buyer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "Email", "Password", "UserType" },
                values: new object[] { "seller", "seller@gmail.com", "seller", "seller" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Asset_condition", "CategoryId", "Cost", "Description", "ExpiryBidDate", "Image", "Name", "StartBidDate", "UserId" },
                values: new object[,]
                {
                    { 1, "new", 1, "12.0", "Prakash has created product stuff", new DateTime(2023, 2, 20, 14, 37, 54, 874, DateTimeKind.Local).AddTicks(1471), "sunflower.png", "Sunflower", new DateTime(2023, 2, 20, 14, 37, 54, 874, DateTimeKind.Local).AddTicks(1422), "seller" },
                    { 2, "old", 2, "12.0", "Prakash has created product stuff", new DateTime(2023, 2, 20, 14, 37, 54, 874, DateTimeKind.Local).AddTicks(1478), "Kitkat.png", "Kitkat", new DateTime(2023, 2, 20, 14, 37, 54, 874, DateTimeKind.Local).AddTicks(1476), "seller" },
                    { 3, "new", 1, "12.0", "Fresh Tulip", new DateTime(2023, 2, 20, 14, 37, 54, 874, DateTimeKind.Local).AddTicks(1483), "tulips.png", "Tulip", new DateTime(2023, 2, 20, 14, 37, 54, 874, DateTimeKind.Local).AddTicks(1481), "seller" },
                    { 4, "old", 2, "12.0", "Sweet in taste", new DateTime(2023, 2, 20, 14, 37, 54, 874, DateTimeKind.Local).AddTicks(1487), "Toblerone.png", "Tobelerone", new DateTime(2023, 2, 20, 14, 37, 54, 874, DateTimeKind.Local).AddTicks(1486), "buyer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserId",
                table: "Products");

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
                table: "Users",
                keyColumn: "Username",
                keyValue: "buyer");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "seller");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Username",
                table: "Products",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_Username",
                table: "Products",
                column: "Username",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
