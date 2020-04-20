using Microsoft.EntityFrameworkCore.Migrations;

namespace BMS.Migrations
{
    public partial class ChangeDbDesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_AircraftCabins_AircraftCabinId",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Passengers_AircraftCabinId",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "AircraftCabinId",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AircraftCabins");

            migrationBuilder.DropColumn(
                name: "ZoneAlphaCapacity",
                table: "AircraftCabins");

            migrationBuilder.DropColumn(
                name: "ZoneBravoCapacity",
                table: "AircraftCabins");

            migrationBuilder.DropColumn(
                name: "ZoneCharlieCapacity",
                table: "AircraftCabins");

            migrationBuilder.DropColumn(
                name: "ZoneDeltaCapacity",
                table: "AircraftCabins");

            migrationBuilder.AddColumn<int>(
                name: "AircraftCabinZoneId",
                table: "Passengers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AircraftCabinId = table.Column<int>(nullable: false),
                    CabinCapacity = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zones_AircraftCabins_AircraftCabinId",
                        column: x => x.AircraftCabinId,
                        principalTable: "AircraftCabins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_AircraftCabinZoneId",
                table: "Passengers",
                column: "AircraftCabinZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_AircraftCabinId",
                table: "Zones",
                column: "AircraftCabinId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Zones_AircraftCabinZoneId",
                table: "Passengers",
                column: "AircraftCabinZoneId",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Zones_AircraftCabinZoneId",
                table: "Passengers");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropIndex(
                name: "IX_Passengers_AircraftCabinZoneId",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "AircraftCabinZoneId",
                table: "Passengers");

            migrationBuilder.AddColumn<int>(
                name: "AircraftCabinId",
                table: "Passengers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AircraftCabins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ZoneAlphaCapacity",
                table: "AircraftCabins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZoneBravoCapacity",
                table: "AircraftCabins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZoneCharlieCapacity",
                table: "AircraftCabins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZoneDeltaCapacity",
                table: "AircraftCabins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_AircraftCabinId",
                table: "Passengers",
                column: "AircraftCabinId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_AircraftCabins_AircraftCabinId",
                table: "Passengers",
                column: "AircraftCabinId",
                principalTable: "AircraftCabins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
