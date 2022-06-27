using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentABoat.Infrastructure.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boat_SailorAccount_SailorAccountId",
                table: "Boat");

            migrationBuilder.DropIndex(
                name: "IX_Boat_SailorAccountId",
                table: "Boat");

            migrationBuilder.AddColumn<int>(
                name: "BoatId",
                table: "SailorAccount",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Boat_SailorAccountId",
                table: "Boat",
                column: "SailorAccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Boat_SailorAccount_SailorAccountId",
                table: "Boat",
                column: "SailorAccountId",
                principalTable: "SailorAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boat_SailorAccount_SailorAccountId",
                table: "Boat");

            migrationBuilder.DropIndex(
                name: "IX_Boat_SailorAccountId",
                table: "Boat");

            migrationBuilder.DropColumn(
                name: "BoatId",
                table: "SailorAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Boat_SailorAccountId",
                table: "Boat",
                column: "SailorAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boat_SailorAccount_SailorAccountId",
                table: "Boat",
                column: "SailorAccountId",
                principalTable: "SailorAccount",
                principalColumn: "Id");
        }
    }
}
