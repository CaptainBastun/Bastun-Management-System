using Microsoft.EntityFrameworkCore.Migrations;

namespace BMS.Migrations
{
    public partial class ChangeMessagePropertyToAllowNulls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suitcases_Compartments_CompartmentId",
                table: "Suitcases");

            migrationBuilder.AddForeignKey(
                name: "FK_Suitcases_Compartments_CompartmentId",
                table: "Suitcases",
                column: "CompartmentId",
                principalTable: "Compartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AlterColumn<string>(
                  name: "OutboundFlightFlightNumber",
                  table: "Messages",
                  nullable: true,
                  oldClrType: typeof(string),
                  oldType: "nvarchar(450)",
                  oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InboundFlightFlightNumber",
                table: "Messages",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suitcases_Compartments_CompartmentId",
                table: "Suitcases");

            migrationBuilder.AddForeignKey(
                name: "FK_Suitcases_Compartments_CompartmentId",
                table: "Suitcases",
                column: "CompartmentId",
                principalTable: "Compartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
