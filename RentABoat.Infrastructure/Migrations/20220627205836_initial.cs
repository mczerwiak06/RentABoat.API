using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentABoat.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SailorAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    ZipCode = table.Column<string>(type: "TEXT", nullable: false),
                    BuildingNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    BoatId = table.Column<int>(type: "INTEGER", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateOfUpdate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SailorAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Length = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfBerths = table.Column<int>(type: "INTEGER", nullable: false),
                    YearOfBuilt = table.Column<int>(type: "INTEGER", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Harbour = table.Column<string>(type: "TEXT", nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    SailorAccountId = table.Column<int>(type: "INTEGER", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateOfUpdate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boat_SailorAccount_SailorAccountId",
                        column: x => x.SailorAccountId,
                        principalTable: "SailorAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boat_SailorAccountId",
                table: "Boat",
                column: "SailorAccountId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boat");

            migrationBuilder.DropTable(
                name: "SailorAccount");
        }
    }
}
