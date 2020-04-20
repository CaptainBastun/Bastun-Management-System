using Microsoft.EntityFrameworkCore.Migrations;

namespace BMS.Migrations
{
    public partial class AddSeatMapConfigToFlightModelEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SeatMap",
                table: "Flights",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatMap",
                table: "Flights");
        }
    }
}
