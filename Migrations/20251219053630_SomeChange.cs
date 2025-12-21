using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPT_Booking_BE.Migrations
{
    /// <inheritdoc />
    public partial class SomeChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "SemesterID", "EndDate", "Name", "StartDate" },
                values: new object[] { 1, new DateOnly(2026, 5, 15), "Học kỳ Spring 2026", new DateOnly(2026, 1, 15) });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "SemesterID", "EndDate", "IsActive", "Name", "StartDate" },
                values: new object[] { 2, new DateOnly(2026, 12, 15), true, "Học kỳ Fall 2026", new DateOnly(2026, 8, 15) });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "SemesterID", "EndDate", "Name", "StartDate" },
                values: new object[] { 3, new DateOnly(2025, 5, 15), "Học kỳ Spring 2025", new DateOnly(2025, 1, 15) });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "SemesterID", "EndDate", "IsActive", "Name", "StartDate" },
                values: new object[] { 4, new DateOnly(2025, 12, 31), true, "Học kỳ Fall 2025", new DateOnly(2025, 8, 15) });
        }
    }
}
