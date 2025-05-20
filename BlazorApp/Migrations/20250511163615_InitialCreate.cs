using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "counters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CurrentCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_counters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "weather_forecasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    TemperatureC = table.Column<int>(type: "integer", nullable: false),
                    Summary = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weather_forecasts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "counters",
                columns: new[] { "Id", "CurrentCount" },
                values: new object[] { 1, 0 });

            migrationBuilder.InsertData(
                table: "weather_forecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 5, 11), "Warm", 20 },
                    { 2, new DateOnly(2023, 5, 12), "Cool", 15 },
                    { 3, new DateOnly(2023, 5, 13), "Cold", 10 },
                    { 4, new DateOnly(2023, 5, 14), "Hot", 25 },
                    { 5, new DateOnly(2023, 5, 15), "Very Hot", 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "counters");

            migrationBuilder.DropTable(
                name: "weather_forecasts");
        }
    }
}
