using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BMS.Migrations
{
    public partial class ChangeArchitecture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aircraft_Flights_OutboundFlightId",
                table: "Aircraft");

            migrationBuilder.DropForeignKey(
                name: "FK_ArrivalMovements_Flights_InboundFlightId",
                table: "ArrivalMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartureMovements_Flights_OutboundFlightId",
                table: "DepartureMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_LoadingInstructions_Flights_OutboundFlightId",
                table: "LoadingInstructions");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Flights_InboundFlightId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Flights_OutboundFlightId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "ContainerInfos");

            migrationBuilder.DropTable(
                name: "Containers");

            migrationBuilder.DropIndex(
                name: "IX_Messages_InboundFlightId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_OutboundFlightId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_LoadingInstructions_OutboundFlightId",
                table: "LoadingInstructions");

            migrationBuilder.DropIndex(
                name: "IX_DepartureMovements_OutboundFlightId",
                table: "DepartureMovements");

            migrationBuilder.DropIndex(
                name: "IX_ArrivalMovements_InboundFlightId",
                table: "ArrivalMovements");

            migrationBuilder.DropIndex(
                name: "IX_Aircraft_OutboundFlightId",
                table: "Aircraft");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flights",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "ContainerInfoId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SupplementaryInformation",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "InboundFlightId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "OutboundFlightId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "OutboundFlightId",
                table: "LoadingInstructions");

            migrationBuilder.DropColumn(
                name: "OutboundFlightId",
                table: "DepartureMovements");

            migrationBuilder.DropColumn(
                name: "InboundFlightId",
                table: "ArrivalMovements");

            migrationBuilder.DropColumn(
                name: "OutboundFlightId",
                table: "Aircraft");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "ArrivalMovementId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Flights");

            migrationBuilder.RenameTable(
                name: "Flights",
                newName: "OutboundFlights");

            migrationBuilder.AddColumn<string>(
                name: "InboundFlightFlightNumber",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OutboundFlightFlightNumber",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OutboundFlightFlightNumber",
                table: "LoadingInstructions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OutboundFlightFlightNumber",
                table: "DepartureMovements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InboundFlightFlightNumber",
                table: "ArrivalMovements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OutboundFlightFlightNumber",
                table: "Aircraft",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LoadingInstructionId",
                table: "OutboundFlights",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeparted",
                table: "OutboundFlights",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Destination",
                table: "OutboundFlights",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartureMovementId",
                table: "OutboundFlights",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookedPAX",
                table: "OutboundFlights",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AircraftId",
                table: "OutboundFlights",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FlightNumber",
                table: "OutboundFlights",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutboundFlights",
                table: "OutboundFlights",
                column: "FlightNumber");

            migrationBuilder.CreateTable(
                name: "InboundFlights",
                columns: table => new
                {
                    FlightNumber = table.Column<string>(nullable: false),
                    ArrivalMovementId = table.Column<int>(nullable: false),
                    Origin = table.Column<string>(nullable: false),
                    STA = table.Column<DateTime>(nullable: false),
                    STD = table.Column<DateTime>(nullable: false),
                    SeatMap = table.Column<string>(nullable: true),
                    RampAgentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboundFlights", x => x.FlightNumber);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_InboundFlightFlightNumber",
                table: "Messages",
                column: "InboundFlightFlightNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_OutboundFlightFlightNumber",
                table: "Messages",
                column: "OutboundFlightFlightNumber");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingInstructions_OutboundFlightFlightNumber",
                table: "LoadingInstructions",
                column: "OutboundFlightFlightNumber",
                unique: true,
                filter: "[OutboundFlightFlightNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DepartureMovements_OutboundFlightFlightNumber",
                table: "DepartureMovements",
                column: "OutboundFlightFlightNumber",
                unique: true,
                filter: "[OutboundFlightFlightNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ArrivalMovements_InboundFlightFlightNumber",
                table: "ArrivalMovements",
                column: "InboundFlightFlightNumber",
                unique: true,
                filter: "[InboundFlightFlightNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_OutboundFlightFlightNumber",
                table: "Aircraft",
                column: "OutboundFlightFlightNumber",
                unique: true,
                filter: "[OutboundFlightFlightNumber] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Aircraft_OutboundFlights_OutboundFlightFlightNumber",
                table: "Aircraft",
                column: "OutboundFlightFlightNumber",
                principalTable: "OutboundFlights",
                principalColumn: "FlightNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArrivalMovements_InboundFlights_InboundFlightFlightNumber",
                table: "ArrivalMovements",
                column: "InboundFlightFlightNumber",
                principalTable: "InboundFlights",
                principalColumn: "FlightNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartureMovements_OutboundFlights_OutboundFlightFlightNumber",
                table: "DepartureMovements",
                column: "OutboundFlightFlightNumber",
                principalTable: "OutboundFlights",
                principalColumn: "FlightNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoadingInstructions_OutboundFlights_OutboundFlightFlightNumber",
                table: "LoadingInstructions",
                column: "OutboundFlightFlightNumber",
                principalTable: "OutboundFlights",
                principalColumn: "FlightNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_InboundFlights_InboundFlightFlightNumber",
                table: "Messages",
                column: "InboundFlightFlightNumber",
                principalTable: "InboundFlights",
                principalColumn: "FlightNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_OutboundFlights_OutboundFlightFlightNumber",
                table: "Messages",
                column: "OutboundFlightFlightNumber",
                principalTable: "OutboundFlights",
                principalColumn: "FlightNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aircraft_OutboundFlights_OutboundFlightFlightNumber",
                table: "Aircraft");

            migrationBuilder.DropForeignKey(
                name: "FK_ArrivalMovements_InboundFlights_InboundFlightFlightNumber",
                table: "ArrivalMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartureMovements_OutboundFlights_OutboundFlightFlightNumber",
                table: "DepartureMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_LoadingInstructions_OutboundFlights_OutboundFlightFlightNumber",
                table: "LoadingInstructions");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_InboundFlights_InboundFlightFlightNumber",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_OutboundFlights_OutboundFlightFlightNumber",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "InboundFlights");

            migrationBuilder.DropIndex(
                name: "IX_Messages_InboundFlightFlightNumber",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_OutboundFlightFlightNumber",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_LoadingInstructions_OutboundFlightFlightNumber",
                table: "LoadingInstructions");

            migrationBuilder.DropIndex(
                name: "IX_DepartureMovements_OutboundFlightFlightNumber",
                table: "DepartureMovements");

            migrationBuilder.DropIndex(
                name: "IX_ArrivalMovements_InboundFlightFlightNumber",
                table: "ArrivalMovements");

            migrationBuilder.DropIndex(
                name: "IX_Aircraft_OutboundFlightFlightNumber",
                table: "Aircraft");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OutboundFlights",
                table: "OutboundFlights");

            migrationBuilder.DropColumn(
                name: "InboundFlightFlightNumber",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "OutboundFlightFlightNumber",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "OutboundFlightFlightNumber",
                table: "LoadingInstructions");

            migrationBuilder.DropColumn(
                name: "OutboundFlightFlightNumber",
                table: "DepartureMovements");

            migrationBuilder.DropColumn(
                name: "InboundFlightFlightNumber",
                table: "ArrivalMovements");

            migrationBuilder.DropColumn(
                name: "OutboundFlightFlightNumber",
                table: "Aircraft");

            migrationBuilder.RenameTable(
                name: "OutboundFlights",
                newName: "Flights");

            migrationBuilder.AddColumn<int>(
                name: "ContainerInfoId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplementaryInformation",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InboundFlightId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OutboundFlightId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OutboundFlightId",
                table: "LoadingInstructions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OutboundFlightId",
                table: "DepartureMovements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InboundFlightId",
                table: "ArrivalMovements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OutboundFlightId",
                table: "Aircraft",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "LoadingInstructionId",
                table: "Flights",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeparted",
                table: "Flights",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "Destination",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "DepartureMovementId",
                table: "Flights",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BookedPAX",
                table: "Flights",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AircraftId",
                table: "Flights",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "FlightNumber",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ArrivalMovementId",
                table: "Flights",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flights",
                table: "Flights",
                column: "FlightId");

            migrationBuilder.CreateTable(
                name: "Containers",
                columns: table => new
                {
                    ContainerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContainerInfoId = table.Column<int>(type: "int", nullable: true),
                    ContainerPieces = table.Column<int>(type: "int", nullable: false),
                    InboundFlightId = table.Column<int>(type: "int", nullable: true),
                    OutboundFlightId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Containers", x => x.ContainerId);
                    table.ForeignKey(
                        name: "FK_Containers_Flights_InboundFlightId",
                        column: x => x.InboundFlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Containers_Flights_OutboundFlightId",
                        column: x => x.OutboundFlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContainerInfos",
                columns: table => new
                {
                    ContainerInfoId = table.Column<int>(type: "int", nullable: false),
                    ContainerId = table.Column<int>(type: "int", nullable: true),
                    ContainerNumberAndType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainerPalletMessageId = table.Column<int>(type: "int", nullable: true),
                    ContainerPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainerTotalWeight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerInfos", x => x.ContainerInfoId);
                    table.ForeignKey(
                        name: "FK_ContainerInfos_Containers_ContainerInfoId",
                        column: x => x.ContainerInfoId,
                        principalTable: "Containers",
                        principalColumn: "ContainerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContainerInfos_Messages_ContainerPalletMessageId",
                        column: x => x.ContainerPalletMessageId,
                        principalTable: "Messages",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_InboundFlightId",
                table: "Messages",
                column: "InboundFlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_OutboundFlightId",
                table: "Messages",
                column: "OutboundFlightId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingInstructions_OutboundFlightId",
                table: "LoadingInstructions",
                column: "OutboundFlightId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartureMovements_OutboundFlightId",
                table: "DepartureMovements",
                column: "OutboundFlightId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArrivalMovements_InboundFlightId",
                table: "ArrivalMovements",
                column: "InboundFlightId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_OutboundFlightId",
                table: "Aircraft",
                column: "OutboundFlightId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContainerInfos_ContainerPalletMessageId",
                table: "ContainerInfos",
                column: "ContainerPalletMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_InboundFlightId",
                table: "Containers",
                column: "InboundFlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_OutboundFlightId",
                table: "Containers",
                column: "OutboundFlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aircraft_Flights_OutboundFlightId",
                table: "Aircraft",
                column: "OutboundFlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArrivalMovements_Flights_InboundFlightId",
                table: "ArrivalMovements",
                column: "InboundFlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartureMovements_Flights_OutboundFlightId",
                table: "DepartureMovements",
                column: "OutboundFlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoadingInstructions_Flights_OutboundFlightId",
                table: "LoadingInstructions",
                column: "OutboundFlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Flights_InboundFlightId",
                table: "Messages",
                column: "InboundFlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Flights_OutboundFlightId",
                table: "Messages",
                column: "OutboundFlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
