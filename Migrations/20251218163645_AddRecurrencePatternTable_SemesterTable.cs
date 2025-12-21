using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPT_Booking_BE.Migrations
{
    /// <inheritdoc />
    public partial class AddRecurrencePatternTable_SemesterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "SecurityTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecurrencePatternId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RecurrencePatterns",
                columns: table => new
                {
                    RecurrencePatternID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecurrenceGroupID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PatternType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DaysOfWeek = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Interval = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Recurren__PATTERN_ID", x => x.RecurrencePatternID);
                    table.ForeignKey(
                        name: "FK_RecurrencePattern_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingID",
                keyValue: 1,
                column: "RecurrencePatternId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingID",
                keyValue: 2,
                column: "RecurrencePatternId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_SecurityTasks_BookingId",
                table: "SecurityTasks",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RecurrencePatternId",
                table: "Bookings",
                column: "RecurrencePatternId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurrencePatterns_CreatedBy",
                table: "RecurrencePatterns",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_RecurrencePattern",
                table: "Bookings",
                column: "RecurrencePatternId",
                principalTable: "RecurrencePatterns",
                principalColumn: "RecurrencePatternID");

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityTasks_Booking",
                table: "SecurityTasks",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_RecurrencePattern",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_SecurityTasks_Booking",
                table: "SecurityTasks");

            migrationBuilder.DropTable(
                name: "RecurrencePatterns");

            migrationBuilder.DropIndex(
                name: "IX_SecurityTasks_BookingId",
                table: "SecurityTasks");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RecurrencePatternId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "SecurityTasks");

            migrationBuilder.DropColumn(
                name: "RecurrencePatternId",
                table: "Bookings");
        }
    }
}
