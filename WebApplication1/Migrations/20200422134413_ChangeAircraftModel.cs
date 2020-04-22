using Microsoft.EntityFrameworkCore.Migrations;

namespace BMS.Migrations
{
    public partial class ChangeAircraftModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAicraftContainerized",
                table: "Aircraft");

            migrationBuilder.AlterColumn<string>(
                name: "OutboundFlightFlightNumber",
                table: "Messages",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InboundFlightFlightNumber",
                table: "Messages",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OutboundFlightFlightNumber",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "InboundFlightFlightNumber",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<bool>(
                name: "IsAicraftContainerized",
                table: "Aircraft",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
