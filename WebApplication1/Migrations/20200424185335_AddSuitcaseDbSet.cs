using Microsoft.EntityFrameworkCore.Migrations;

namespace BMS.Migrations
{
    public partial class AddSuitcaseDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suitcase_Compartments_CompartmentId",
                table: "Suitcase");

            migrationBuilder.DropForeignKey(
                name: "FK_Suitcase_Passengers_PassengerPaxId",
                table: "Suitcase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suitcase",
                table: "Suitcase");

            migrationBuilder.RenameTable(
                name: "Suitcase",
                newName: "Suitcases");

            migrationBuilder.RenameIndex(
                name: "IX_Suitcase_PassengerPaxId",
                table: "Suitcases",
                newName: "IX_Suitcases_PassengerPaxId");

            migrationBuilder.RenameIndex(
                name: "IX_Suitcase_CompartmentId",
                table: "Suitcases",
                newName: "IX_Suitcases_CompartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suitcases",
                table: "Suitcases",
                column: "SuitcaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suitcases_Compartments_CompartmentId",
                table: "Suitcases",
                column: "CompartmentId",
                principalTable: "Compartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suitcases_Passengers_PassengerPaxId",
                table: "Suitcases",
                column: "PassengerPaxId",
                principalTable: "Passengers",
                principalColumn: "PaxId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suitcases_Compartments_CompartmentId",
                table: "Suitcases");

            migrationBuilder.DropForeignKey(
                name: "FK_Suitcases_Passengers_PassengerPaxId",
                table: "Suitcases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suitcases",
                table: "Suitcases");

            migrationBuilder.RenameTable(
                name: "Suitcases",
                newName: "Suitcase");

            migrationBuilder.RenameIndex(
                name: "IX_Suitcases_PassengerPaxId",
                table: "Suitcase",
                newName: "IX_Suitcase_PassengerPaxId");

            migrationBuilder.RenameIndex(
                name: "IX_Suitcases_CompartmentId",
                table: "Suitcase",
                newName: "IX_Suitcase_CompartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suitcase",
                table: "Suitcase",
                column: "SuitcaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suitcase_Compartments_CompartmentId",
                table: "Suitcase",
                column: "CompartmentId",
                principalTable: "Compartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suitcase_Passengers_PassengerPaxId",
                table: "Suitcase",
                column: "PassengerPaxId",
                principalTable: "Passengers",
                principalColumn: "PaxId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
