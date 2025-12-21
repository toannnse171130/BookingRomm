using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPT_Booking_BE.Migrations
{
    /// <inheritdoc />
    public partial class AddSemester : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingID",
                keyValue: 1,
                column: "BookingDate",
                value: new DateOnly(2025, 12, 19));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingID",
                keyValue: 2,
                column: "BookingDate",
                value: new DateOnly(2025, 12, 20));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "CreatedAt", "Email", "FullName", "IsActive", "PasswordHash", "PhoneNumber", "RoleID" },
                values: new object[] { 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "string", "Nguyễn Quản Admin", true, "string", "0901234567", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingID",
                keyValue: 1,
                column: "BookingDate",
                value: new DateOnly(2025, 12, 18));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingID",
                keyValue: 2,
                column: "BookingDate",
                value: new DateOnly(2025, 12, 19));
        }
    }
}
