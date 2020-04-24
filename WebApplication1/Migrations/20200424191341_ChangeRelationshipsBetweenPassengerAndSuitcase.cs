using Microsoft.EntityFrameworkCore.Migrations;

namespace BMS.Migrations
{
    public partial class ChangeRelationshipsBetweenPassengerAndSuitcase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suitcases_Passengers_PassengerPaxId",
                table: "Suitcases");

            migrationBuilder.DropIndex(
                name: "IX_Suitcases_PassengerPaxId",
                table: "Suitcases");

            migrationBuilder.DropColumn(
                name: "PassengerPaxId",
                table: "Suitcases");

            migrationBuilder.DropColumn(
                name: "PaxId",
                table: "Suitcases");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PassengerPaxId",
                table: "Suitcases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaxId",
                table: "Suitcases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Suitcases_PassengerPaxId",
                table: "Suitcases",
                column: "PassengerPaxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suitcases_Passengers_PassengerPaxId",
                table: "Suitcases",
                column: "PassengerPaxId",
                principalTable: "Passengers",
                principalColumn: "PaxId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
