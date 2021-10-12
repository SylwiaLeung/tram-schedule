using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tram_Schedule.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TramRoutes",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "Papieski" });

            migrationBuilder.InsertData(
                table: "TramRoutes",
                columns: new[] { "ID", "Name" },
                values: new object[] { 2, "Wawelski" });

            migrationBuilder.InsertData(
                table: "Trams",
                columns: new[] { "ID", "FirstRun", "Name" },
                values: new object[] { 1, new DateTime(1988, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "PapaTram" });

            migrationBuilder.InsertData(
                table: "Trams",
                columns: new[] { "ID", "FirstRun", "Name" },
                values: new object[] { 2, new DateTime(2018, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "VintageTram" });

            migrationBuilder.InsertData(
                table: "TramStops",
                columns: new[] { "ID", "Description", "Name", "RouteID" },
                values: new object[] { 1, "This stop is the best of them all", "Sanktuarium", 1 });

            migrationBuilder.InsertData(
                table: "TramStops",
                columns: new[] { "ID", "Description", "Name", "RouteID" },
                values: new object[] { 2, "This stop is very far", "Borek", 1 });

            migrationBuilder.InsertData(
                table: "TramStops",
                columns: new[] { "ID", "Description", "Name", "RouteID" },
                values: new object[] { 3, "This stop lies near a very good cafe", "Stradom", 2 });

            migrationBuilder.InsertData(
                table: "TramStops",
                columns: new[] { "ID", "Description", "Name", "RouteID" },
                values: new object[] { 4, "This stop is situated by the Wawel castle", "Wawel", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TramStops",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TramStops",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TramStops",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TramStops",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trams",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trams",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TramRoutes",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TramRoutes",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
