using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FPT_Booking_BE.Migrations
{
    /// <inheritdoc />
    public partial class SeparateRecurrencePatternType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatternType",
                table: "RecurrencePatterns");

            migrationBuilder.AddColumn<int>(
                name: "PatternTypeID",
                table: "RecurrencePatterns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RecurrencePatternTypes",
                columns: table => new
                {
                    PatternTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RecurrencePatternType__ID", x => x.PatternTypeID);
                });

            migrationBuilder.InsertData(
                table: "RecurrencePatternTypes",
                columns: new[] { "PatternTypeID", "Description", "TypeName" },
                values: new object[,]
                {
                    { 1, "Repeat every day", "Daily" },
                    { 2, "Repeat every week on the same day(s)", "Weekly" },
                    { 3, "Repeat on weekdays only (Monday to Friday)", "Weekdays" },
                    { 4, "Repeat on weekends only (Saturday and Sunday)", "Weekends" },
                    { 5, "Repeat every month on the same date", "Monthly" },
                    { 6, "Custom pattern - specify which days of week", "Custom" },
                    { 7, "Repeat for the entire semester", "Semesterly" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecurrencePatterns_PatternTypeID",
                table: "RecurrencePatterns",
                column: "PatternTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_RecurrencePattern_PatternType",
                table: "RecurrencePatterns",
                column: "PatternTypeID",
                principalTable: "RecurrencePatternTypes",
                principalColumn: "PatternTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecurrencePattern_PatternType",
                table: "RecurrencePatterns");

            migrationBuilder.DropTable(
                name: "RecurrencePatternTypes");

            migrationBuilder.DropIndex(
                name: "IX_RecurrencePatterns_PatternTypeID",
                table: "RecurrencePatterns");

            migrationBuilder.DropColumn(
                name: "PatternTypeID",
                table: "RecurrencePatterns");

            migrationBuilder.AddColumn<string>(
                name: "PatternType",
                table: "RecurrencePatterns",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
