using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FPT_Booking_BE.Migrations
{
    /// <inheritdoc />
    public partial class AddSemesterDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "SemesterID", "EndDate", "IsActive", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 12, 28), true, "Fall 2025", new DateOnly(2025, 9, 1) },
                    { 2, new DateOnly(2025, 8, 31), true, "Summer 2025", new DateOnly(2025, 6, 1) },
                    { 3, new DateOnly(2026, 3, 15), true, "Spring 2026", new DateOnly(2026, 1, 1) },
                    { 4, new DateOnly(2026, 8, 31), true, "Summer 2026", new DateOnly(2026, 4, 1) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "SemesterID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "SemesterID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "SemesterID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "SemesterID",
                keyValue: 4);
        }
    }
}
