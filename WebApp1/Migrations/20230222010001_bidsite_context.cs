using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp1.Migrations
{
    public partial class bidsite_context : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpiryBidDate", "StartBidDate" },
                values: new object[] { new DateTime(2023, 2, 22, 9, 0, 0, 736, DateTimeKind.Local).AddTicks(8000), new DateTime(2023, 2, 22, 9, 0, 0, 736, DateTimeKind.Local).AddTicks(7991) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpiryBidDate", "StartBidDate" },
                values: new object[] { new DateTime(2023, 2, 22, 9, 0, 0, 736, DateTimeKind.Local).AddTicks(8005), new DateTime(2023, 2, 22, 9, 0, 0, 736, DateTimeKind.Local).AddTicks(8004) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExpiryBidDate", "StartBidDate" },
                values: new object[] { new DateTime(2023, 2, 22, 9, 0, 0, 736, DateTimeKind.Local).AddTicks(8007), new DateTime(2023, 2, 22, 9, 0, 0, 736, DateTimeKind.Local).AddTicks(8007) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExpiryBidDate", "StartBidDate" },
                values: new object[] { new DateTime(2023, 2, 22, 9, 0, 0, 736, DateTimeKind.Local).AddTicks(8010), new DateTime(2023, 2, 22, 9, 0, 0, 736, DateTimeKind.Local).AddTicks(8009) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpiryBidDate", "StartBidDate" },
                values: new object[] { new DateTime(2023, 2, 20, 20, 56, 25, 291, DateTimeKind.Local).AddTicks(4762), new DateTime(2023, 2, 20, 20, 56, 25, 291, DateTimeKind.Local).AddTicks(4724) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpiryBidDate", "StartBidDate" },
                values: new object[] { new DateTime(2023, 2, 20, 20, 56, 25, 291, DateTimeKind.Local).AddTicks(4766), new DateTime(2023, 2, 20, 20, 56, 25, 291, DateTimeKind.Local).AddTicks(4765) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExpiryBidDate", "StartBidDate" },
                values: new object[] { new DateTime(2023, 2, 20, 20, 56, 25, 291, DateTimeKind.Local).AddTicks(4769), new DateTime(2023, 2, 20, 20, 56, 25, 291, DateTimeKind.Local).AddTicks(4768) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExpiryBidDate", "StartBidDate" },
                values: new object[] { new DateTime(2023, 2, 20, 20, 56, 25, 291, DateTimeKind.Local).AddTicks(4771), new DateTime(2023, 2, 20, 20, 56, 25, 291, DateTimeKind.Local).AddTicks(4770) });
        }
    }
}
