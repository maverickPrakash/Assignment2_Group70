using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp1.Migrations
{
    public partial class newData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Asset_condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartBidDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryBidDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Users_Username1",
                        column: x => x.Username1,
                        principalTable: "Users",
                        principalColumn: "Username");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Home" },
                    { 2, "Electronic" },
                    { 3, "Fashion" },
                    { 4, "Game" },
                    { 5, "Books" },
                    { 6, "Computer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "Email", "Password", "UserType" },
                values: new object[,]
                {
                    { "buyer", "buer@gmail.com", "buyer", "buyer" },
                    { "seller", "seller@gmail.com", "seller", "seller" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Asset_condition", "CategoryId", "Cost", "Description", "ExpiryBidDate", "Image", "Name", "StartBidDate", "Username", "Username1" },
                values: new object[,]
                {
                    { 1, "new", 1, "12.0", "Prakash has created product stuff", new DateTime(2023, 2, 21, 16, 36, 1, 119, DateTimeKind.Local).AddTicks(6595), "sunflower.jgp", "Sunflower", new DateTime(2023, 2, 21, 16, 36, 1, 119, DateTimeKind.Local).AddTicks(6554), "seller", null },
                    { 2, "old", 2, "12.0", "Prakash has created product stuff", new DateTime(2023, 2, 21, 16, 36, 1, 119, DateTimeKind.Local).AddTicks(6633), "Kitkat.jpg", "Kitkat", new DateTime(2023, 2, 21, 16, 36, 1, 119, DateTimeKind.Local).AddTicks(6631), "seller", null },
                    { 3, "new", 1, "12.0", "Fresh Tulip", new DateTime(2023, 2, 21, 16, 36, 1, 119, DateTimeKind.Local).AddTicks(6637), "tulips.jpg", "Tulip", new DateTime(2023, 2, 21, 16, 36, 1, 119, DateTimeKind.Local).AddTicks(6636), "seller", null },
                    { 4, "old", 2, "12.0", "Sweet in taste", new DateTime(2023, 2, 21, 16, 36, 1, 119, DateTimeKind.Local).AddTicks(6639), "Toblerone.jpg", "Tobelerone", new DateTime(2023, 2, 21, 16, 36, 1, 119, DateTimeKind.Local).AddTicks(6638), "buyer", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Username1",
                table: "Products",
                column: "Username1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
