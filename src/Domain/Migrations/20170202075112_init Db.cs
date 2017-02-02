using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diagnostics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeviceName = table.Column<string>(nullable: true),
                    DeviceNumber = table.Column<int>(nullable: false),
                    Fault = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RailwayStations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RailwayStations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    EcpCode = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RailwayStStationStations",
                columns: table => new
                {
                    RailStId = table.Column<int>(nullable: false),
                    StatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RailwayStStationStations", x => new { x.RailStId, x.StatId });
                    table.ForeignKey(
                        name: "FK_RailwayStStationStations_RailwayStations_RailStId",
                        column: x => x.RailStId,
                        principalTable: "RailwayStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RailwayStStationStations_Stations_StatId",
                        column: x => x.StatId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegulatorySchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaysFollowings = table.Column<string>(nullable: true),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DestId = table.Column<int>(nullable: false),
                    DispId = table.Column<int>(nullable: false),
                    NumberOfTrain = table.Column<string>(maxLength: 10, nullable: false),
                    RailwayStId = table.Column<int>(nullable: false),
                    RouteName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegulatorySchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegulatorySchedules_Stations_DestId",
                        column: x => x.DestId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegulatorySchedules_Stations_DispId",
                        column: x => x.DispId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegulatorySchedules_RailwayStations_RailwayStId",
                        column: x => x.RailwayStId,
                        principalTable: "RailwayStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegShStationsListOfStops",
                columns: table => new
                {
                    RegShId = table.Column<int>(nullable: false),
                    StatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegShStationsListOfStops", x => new { x.RegShId, x.StatId });
                    table.ForeignKey(
                        name: "FK_RegShStationsListOfStops_RegulatorySchedules_RegShId",
                        column: x => x.RegShId,
                        principalTable: "RegulatorySchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegShStationsListOfStops_Stations_StatId",
                        column: x => x.StatId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegShStationsListWithOutStops",
                columns: table => new
                {
                    RegShId = table.Column<int>(nullable: false),
                    StatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegShStationsListWithOutStops", x => new { x.RegShId, x.StatId });
                    table.ForeignKey(
                        name: "FK_RegShStationsListWithOutStops_RegulatorySchedules_RegShId",
                        column: x => x.RegShId,
                        principalTable: "RegulatorySchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegShStationsListWithOutStops_Stations_StatId",
                        column: x => x.StatId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RailwayStStationStations_StatId",
                table: "RailwayStStationStations",
                column: "StatId");

            migrationBuilder.CreateIndex(
                name: "IX_RegShStationsListOfStops_StatId",
                table: "RegShStationsListOfStops",
                column: "StatId");

            migrationBuilder.CreateIndex(
                name: "IX_RegShStationsListWithOutStops_StatId",
                table: "RegShStationsListWithOutStops",
                column: "StatId");

            migrationBuilder.CreateIndex(
                name: "IX_RegulatorySchedules_DestId",
                table: "RegulatorySchedules",
                column: "DestId");

            migrationBuilder.CreateIndex(
                name: "IX_RegulatorySchedules_DispId",
                table: "RegulatorySchedules",
                column: "DispId");

            migrationBuilder.CreateIndex(
                name: "IX_RegulatorySchedules_RailwayStId",
                table: "RegulatorySchedules",
                column: "RailwayStId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnostics");

            migrationBuilder.DropTable(
                name: "RailwayStStationStations");

            migrationBuilder.DropTable(
                name: "RegShStationsListOfStops");

            migrationBuilder.DropTable(
                name: "RegShStationsListWithOutStops");

            migrationBuilder.DropTable(
                name: "RegulatorySchedules");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "RailwayStations");
        }
    }
}
