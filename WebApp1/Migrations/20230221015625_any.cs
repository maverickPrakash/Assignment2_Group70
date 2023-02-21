using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp1.Migrations
{
    public partial class any : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Products",
                newName: "Username1");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UserId",
                table: "Products",
                newName: "IX_Products_Username1");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpiryBidDate", "StartBidDate", "Username", "Username1" },
                values: new object[] { new DateTime(2023, 2, 20, 20, 56, 25, 291, DateTimeKind.Local).AddTicks(4762), new DateTime(2023, 2, 20, 20, 56, 25, 291, DateTimeKind.Local).AddTicks(4724), "seller", null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpiryBidDate", "StartBidDate", "Username", "Username1" },
                values: new object[] { new DateTime(2023, 2, 20, 20, 56, 25, 291, DateTimeKind.Local).AddTicks(4766), new DateTime(2023, 2, 20, 20, 56, 25, 291, DateTimeKind.Local).AddTicks(4765), "seller", null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExpiryBidDate", "StartBidDate", "Username", "Username1" },
                values: new object[] { new DateTime(2023, 2, 20, 20, 56, 25, 291, DateTimeKind.Local).AddTicks(4769), new DateTime(2023, 2, 20, 20, 56, 25, 291, DateTimeKind.Local).AddTicks(4768), "seller", null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExpiryBidDate", "StartBidDate", "Username", "Username1" },
                values: new object[] { new DateTime(2023, 2, 20, 20, 56, 25, 291, DateTimeKind.Local).AddTicks(4771), new DateTime(2023, 2, 20, 20, 56, 25, 291, DateTimeKind.Local).AddTicks(4770), "buyer", null });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_Username1",
                table: "Products",
                column: "Username1",
                principalTable: "Users",
                principalColumn: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_Username1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Username1",
                table: "Products",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Username1",
                table: "Products",
                newName: "IX_Products_UserId");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpiryBidDate", "StartBidDate", "UserId" },
                values: new object[] { new DateTime(2023, 2, 20, 14, 37, 54, 874, DateTimeKind.Local).AddTicks(1471), new DateTime(2023, 2, 20, 14, 37, 54, 874, DateTimeKind.Local).AddTicks(1422), "seller" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpiryBidDate", "StartBidDate", "UserId" },
                values: new object[] { new DateTime(2023, 2, 20, 14, 37, 54, 874, DateTimeKind.Local).AddTicks(1478), new DateTime(2023, 2, 20, 14, 37, 54, 874, DateTimeKind.Local).AddTicks(1476), "seller" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExpiryBidDate", "StartBidDate", "UserId" },
                values: new object[] { new DateTime(2023, 2, 20, 14, 37, 54, 874, DateTimeKind.Local).AddTicks(1483), new DateTime(2023, 2, 20, 14, 37, 54, 874, DateTimeKind.Local).AddTicks(1481), "seller" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExpiryBidDate", "StartBidDate", "UserId" },
                values: new object[] { new DateTime(2023, 2, 20, 14, 37, 54, 874, DateTimeKind.Local).AddTicks(1487), new DateTime(2023, 2, 20, 14, 37, 54, 874, DateTimeKind.Local).AddTicks(1486), "buyer" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Username");
        }
    }
}
