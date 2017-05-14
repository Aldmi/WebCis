using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class M2MRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegShStationsRouteRoutes",
                columns: table => new
                {
                    RegShId = table.Column<int>(nullable: false),
                    StatRouteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegShStationsRouteRoutes", x => new { x.RegShId, x.StatRouteId });
                    table.ForeignKey(
                        name: "FK_RegShStationsRouteRoutes_RegulatorySchedules_RegShId",
                        column: x => x.RegShId,
                        principalTable: "RegulatorySchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegShStationsRouteRoutes_StationsRoute_StatRouteId",
                        column: x => x.StatRouteId,
                        principalTable: "StationsRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegShStationsRouteRoutes_StatRouteId",
                table: "RegShStationsRouteRoutes",
                column: "StatRouteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegShStationsRouteRoutes");
        }
    }
}
