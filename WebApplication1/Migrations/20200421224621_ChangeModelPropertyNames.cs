using Microsoft.EntityFrameworkCore.Migrations;

namespace BMS.Migrations
{
    public partial class ChangeModelPropertyNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CabinCapacity",
                table: "CabinZones");

            migrationBuilder.AddColumn<int>(
                name: "ZoneCapacity",
                table: "CabinZones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ZoneType",
                table: "CabinZones",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZoneCapacity",
                table: "CabinZones");

            migrationBuilder.DropColumn(
                name: "ZoneType",
                table: "CabinZones");

            migrationBuilder.AddColumn<int>(
                name: "CabinCapacity",
                table: "CabinZones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
