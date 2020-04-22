using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BMS.Migrations
{
    public partial class RemoveSTDFromInboundFlights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RampAgentName",
                table: "InboundFlights");

            migrationBuilder.DropColumn(
                name: "STD",
                table: "InboundFlights");

            migrationBuilder.DropColumn(
                name: "SeatMap",
                table: "InboundFlights");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RampAgentName",
                table: "InboundFlights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "STD",
                table: "InboundFlights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SeatMap",
                table: "InboundFlights",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
