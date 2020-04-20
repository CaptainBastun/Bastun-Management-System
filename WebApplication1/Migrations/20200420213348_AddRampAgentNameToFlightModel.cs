using Microsoft.EntityFrameworkCore.Migrations;

namespace BMS.Migrations
{
    public partial class AddRampAgentNameToFlightModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RampAgentName",
                table: "Flights",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RampAgentName",
                table: "Flights");
        }
    }
}
