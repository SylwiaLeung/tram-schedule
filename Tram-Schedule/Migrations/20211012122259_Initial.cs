using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tram_Schedule.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TramRoutes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TramRoutes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trams",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    FirstRun = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trams", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TramStops",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    RouteID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TramStops", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TramStops_TramRoutes_RouteID",
                        column: x => x.RouteID,
                        principalTable: "TramRoutes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TramStops_RouteID",
                table: "TramStops",
                column: "RouteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trams");

            migrationBuilder.DropTable(
                name: "TramStops");

            migrationBuilder.DropTable(
                name: "TramRoutes");
        }
    }
}
