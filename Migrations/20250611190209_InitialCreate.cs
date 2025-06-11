using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_BOOKING",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PROPERTYID = table.Column<int>(type: "int", nullable: false),
                    USERID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BOOKINGDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_BOOKING", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_PROPERTYS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LOCATION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ISAVILABLE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PROPERTYS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_USERS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FULLNAME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PASSWORDHASH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ROLE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USERS", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "TB_BOOKING",
                columns: new[] { "ID", "BOOKINGDATE", "PROPERTYID", "STATUS", "USERID" },
                values: new object[,]
                {
                    { new Guid("45a8ae32-d47c-408c-950c-064f7d91126b"), new DateTime(2025, 6, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, new Guid("9d7164e0-19e1-4f16-9343-1a9d2c1c055a") },
                    { new Guid("5f989dd7-712b-4a9f-891c-4a4476f2fa8d"), new DateTime(2025, 6, 4, 9, 30, 0, 0, DateTimeKind.Unspecified), 4, 1, new Guid("7fc7cf98-fb79-4e4e-9b87-8f7415c53127") },
                    { new Guid("a4eb2283-f1c1-4f1c-a003-b765f91a77f4"), new DateTime(2025, 6, 2, 11, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, new Guid("f9e2f74d-8327-44c3-a676-fc4e3a9ffae2") },
                    { new Guid("e8c4c038-04e9-4f1b-8f97-07f68b74e5bb"), new DateTime(2025, 6, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, new Guid("7fc7cf98-fb79-4e4e-9b87-8f7415c53127") }
                });

            migrationBuilder.InsertData(
                table: "TB_PROPERTYS",
                columns: new[] { "ID", "ISAVILABLE", "LOCATION", "NAME", "PRICE" },
                values: new object[,]
                {
                    { new Guid("109e3fcd-f279-4a36-b34a-6224ed264b7c"), false, "New York", "City Loft", 500000.00m },
                    { new Guid("24c771fc-3e5e-4de2-bc6a-e5c880894263"), false, "Miami", "Ocean Breeze Apartment", 180000.00m },
                    { new Guid("5d7b3280-7125-4f40-bcc0-b19ad66e5738"), false, "Denver", "Mountain Retreat", 320000.00m },
                    { new Guid("f0a0c92b-7f5e-43a4-9501-bb445ac6ab81"), false, "Los Angeles", "Sunset Villa", 250000.00m }
                });

            migrationBuilder.InsertData(
                table: "TB_USERS",
                columns: new[] { "ID", "EMAIL", "FULLNAME", "PASSWORDHASH", "ROLE" },
                values: new object[,]
                {
                    { new Guid("7fc7cf98-fb79-4e4e-9b87-8f7415c53127"), "John2@yahoo.com", "John", "123", 1 },
                    { new Guid("9d7164e0-19e1-4f16-9343-1a9d2c1c055a"), "mike3@gmai.com", "Mike Brown", "A425", 1 },
                    { new Guid("f9e2f74d-8327-44c3-a676-fc4e3a9ffae2"), "jane2@yahoo.com", "Jane Smith", "456", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_BOOKING");

            migrationBuilder.DropTable(
                name: "TB_PROPERTYS");

            migrationBuilder.DropTable(
                name: "TB_USERS");
        }
    }
}
