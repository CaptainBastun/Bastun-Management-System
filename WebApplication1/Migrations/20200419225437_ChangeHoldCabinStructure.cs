using Microsoft.EntityFrameworkCore.Migrations;

namespace BMS.Migrations
{
    public partial class ChangeHoldCabinStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AircraftBaggageHolds_Aircraft_AircraftId",
                table: "AircraftBaggageHolds");

            migrationBuilder.DropForeignKey(
                name: "FK_AircraftCabins_Aircraft_AircraftId",
                table: "AircraftCabins");

            migrationBuilder.DropForeignKey(
                name: "FK_FuelForms_Aircraft_AircraftId",
                table: "FuelForms");

            migrationBuilder.DropForeignKey(
                name: "FK_WeightForms_Aircraft_AircraftId",
                table: "WeightForms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AircraftBaggageHolds",
                table: "AircraftBaggageHolds");

            migrationBuilder.RenameTable(
                name: "AircraftBaggageHolds",
                newName: "AircraftBaggageHold");

            migrationBuilder.RenameIndex(
                name: "IX_AircraftBaggageHolds_AircraftId",
                table: "AircraftBaggageHold",
                newName: "IX_AircraftBaggageHold_AircraftId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AircraftCabins",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AircraftBaggageHold",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AircraftBaggageHold",
                table: "AircraftBaggageHold",
                column: "BaggageHoldId");

            migrationBuilder.AddForeignKey(
                name: "FK_AircraftBaggageHold_Aircraft_AircraftId",
                table: "AircraftBaggageHold",
                column: "AircraftId",
                principalTable: "Aircraft",
                principalColumn: "AircraftId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AircraftCabins_Aircraft_AircraftId",
                table: "AircraftCabins",
                column: "AircraftId",
                principalTable: "Aircraft",
                principalColumn: "AircraftId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FuelForms_Aircraft_AircraftId",
                table: "FuelForms",
                column: "AircraftId",
                principalTable: "Aircraft",
                principalColumn: "AircraftId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeightForms_Aircraft_AircraftId",
                table: "WeightForms",
                column: "AircraftId",
                principalTable: "Aircraft",
                principalColumn: "AircraftId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AircraftBaggageHold_Aircraft_AircraftId",
                table: "AircraftBaggageHold");

            migrationBuilder.DropForeignKey(
                name: "FK_AircraftCabins_Aircraft_AircraftId",
                table: "AircraftCabins");

            migrationBuilder.DropForeignKey(
                name: "FK_FuelForms_Aircraft_AircraftId",
                table: "FuelForms");

            migrationBuilder.DropForeignKey(
                name: "FK_WeightForms_Aircraft_AircraftId",
                table: "WeightForms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AircraftBaggageHold",
                table: "AircraftBaggageHold");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AircraftCabins");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AircraftBaggageHold");

            migrationBuilder.RenameTable(
                name: "AircraftBaggageHold",
                newName: "AircraftBaggageHolds");

            migrationBuilder.RenameIndex(
                name: "IX_AircraftBaggageHold_AircraftId",
                table: "AircraftBaggageHolds",
                newName: "IX_AircraftBaggageHolds_AircraftId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AircraftBaggageHolds",
                table: "AircraftBaggageHolds",
                column: "BaggageHoldId");

            migrationBuilder.AddForeignKey(
                name: "FK_AircraftBaggageHolds_Aircraft_AircraftId",
                table: "AircraftBaggageHolds",
                column: "AircraftId",
                principalTable: "Aircraft",
                principalColumn: "AircraftId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AircraftCabins_Aircraft_AircraftId",
                table: "AircraftCabins",
                column: "AircraftId",
                principalTable: "Aircraft",
                principalColumn: "AircraftId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FuelForms_Aircraft_AircraftId",
                table: "FuelForms",
                column: "AircraftId",
                principalTable: "Aircraft",
                principalColumn: "AircraftId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeightForms_Aircraft_AircraftId",
                table: "WeightForms",
                column: "AircraftId",
                principalTable: "Aircraft",
                principalColumn: "AircraftId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
