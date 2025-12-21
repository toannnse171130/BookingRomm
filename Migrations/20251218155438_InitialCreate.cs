using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FPT_Booking_BE.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AssetType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Assets__434923723A6A61AA", x => x.AssetID);
                });

            migrationBuilder.CreateTable(
                name: "Campuses",
                columns: table => new
                {
                    CampusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampusName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Campuses__FD598D3696DA5EA2", x => x.CampusID);
                });

            migrationBuilder.CreateTable(
                name: "FacilityTypes",
                columns: table => new
                {
                    TypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RequiresApproval = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Facility__516F039515EF4403", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__8AFACE3AB5D9A902", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Slots",
                columns: table => new
                {
                    SlotID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlotName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Slots__0A124A4F26F6E8CC", x => x.SlotID);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    FacilityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CampusID = table.Column<int>(type: "int", nullable: false),
                    TypeID = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Available"),
                    ImageURL = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Faciliti__5FB08B9477278C1D", x => x.FacilityID);
                    table.ForeignKey(
                        name: "FK__Facilitie__Campu__60A75C0F",
                        column: x => x.CampusID,
                        principalTable: "Campuses",
                        principalColumn: "CampusID");
                    table.ForeignKey(
                        name: "FK__Facilitie__TypeI__619B8048",
                        column: x => x.TypeID,
                        principalTable: "FacilityTypes",
                        principalColumn: "TypeID");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__1788CCACBAD4AC53", x => x.UserID);
                    table.ForeignKey(
                        name: "FK__Users__RoleID__5AEE82B9",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "FacilityAssets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityID = table.Column<int>(type: "int", nullable: false),
                    AssetID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    Condition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "Tốt")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Facility__3214EC27B673F84B", x => x.ID);
                    table.ForeignKey(
                        name: "FK__FacilityA__Asset__6754599E",
                        column: x => x.AssetID,
                        principalTable: "Assets",
                        principalColumn: "AssetID");
                    table.ForeignKey(
                        name: "FK__FacilityA__Facil__66603565",
                        column: x => x.FacilityID,
                        principalTable: "Facilities",
                        principalColumn: "FacilityID");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FacilityID = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SlotID = table.Column<int>(type: "int", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BookingType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Individual"),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Pending"),
                    PriorityLevel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Medium"),
                    ApproverID = table.Column<int>(type: "int", nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    RecurrenceGroupID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bookings__73951ACD0D86927F", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Bookings_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK__Bookings__Approv__73BA3083",
                        column: x => x.ApproverID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK__Bookings__Facili__72C60C4A",
                        column: x => x.FacilityID,
                        principalTable: "Facilities",
                        principalColumn: "FacilityID");
                    table.ForeignKey(
                        name: "FK__Bookings__SlotID__74AE54BC",
                        column: x => x.SlotID,
                        principalTable: "Slots",
                        principalColumn: "SlotID");
                    table.ForeignKey(
                        name: "FK__Bookings__UserID__71D1E811",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "System"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__20CF2E325A705AD8", x => x.NotificationID);
                    table.ForeignKey(
                        name: "FK__Notificat__UserI__02084FDA",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "SecurityTasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Pending"),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Normal"),
                    AssignedToUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CompletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    ReportNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Security__7C6949B1C91D2A0E", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_SecurityTasks_AssignedToUser",
                        column: x => x.AssignedToUserId,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_SecurityTasks_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FacilityID = table.Column<int>(type: "int", nullable: true),
                    BookingID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Pending"),
                    ReportType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ResolvedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reports__D5BD48E52C7C967E", x => x.ReportID);
                    table.ForeignKey(
                        name: "FK__Reports__Booking__7C4F7684",
                        column: x => x.BookingID,
                        principalTable: "Bookings",
                        principalColumn: "BookingID");
                    table.ForeignKey(
                        name: "FK__Reports__Facilit__7B5B524B",
                        column: x => x.FacilityID,
                        principalTable: "Facilities",
                        principalColumn: "FacilityID");
                    table.ForeignKey(
                        name: "FK__Reports__UserID__7A672E12",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetID", "AssetName", "AssetType", "Description" },
                values: new object[,]
                {
                    { 1, "Máy chiếu Sony 4K", "Điện tử", "Máy chiếu chất lượng cao" },
                    { 2, "PC Gaming ROG", "Máy tính", "Máy tính gaming hiệu năng cao" },
                    { 3, "Loa JBL Hall", "Âm thanh", "Hệ thống âm thanh hội trường" },
                    { 4, "Điều hòa Daikin", "Điện lạnh", "Máy điều hòa công suất lớn" }
                });

            migrationBuilder.InsertData(
                table: "Campuses",
                columns: new[] { "CampusID", "Address", "CampusName", "IsActive" },
                values: new object[,]
                {
                    { 1, "Lô E2a-7, Đường D1, Khu Công Nghệ Cao, Tp. Thủ Đức", "FU FPT High Tech Park", true },
                    { 2, "04 Phạm Ngọc Thạch, Bến Nghé, Quận 1", "NVH Thanh Nien", true }
                });

            migrationBuilder.InsertData(
                table: "FacilityTypes",
                columns: new[] { "TypeID", "Description", "RequiresApproval", "TypeName" },
                values: new object[,]
                {
                    { 1, "Phòng học thông thường", false, "Phòng học" },
                    { 2, "Phòng thí nghiệm", true, "Phòng Lab" },
                    { 3, "Hội trường sự kiện", true, "Hội trường" },
                    { 4, "Sân thể thao", false, "Sân thể thao" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "Description", "RoleName" },
                values: new object[,]
                {
                    { 1, "Quản trị viên hệ thống", "Admin" },
                    { 2, "Người duyệt phòng", "FacilityAdmin" },
                    { 3, "Sinh viên", "Student" },
                    { 4, "Giảng viên", "Lecturer" },
                    { 5, "Quản lý thiết bị", "Manager" },
                    { 6, "Bảo vệ", "Security" }
                });

            migrationBuilder.InsertData(
                table: "Slots",
                columns: new[] { "SlotID", "EndTime", "IsActive", "SlotName", "StartTime" },
                values: new object[,]
                {
                    { 1, new TimeOnly(9, 15, 0), true, "Slot 1", new TimeOnly(7, 0, 0) },
                    { 2, new TimeOnly(11, 45, 0), true, "Slot 2", new TimeOnly(9, 30, 0) },
                    { 3, new TimeOnly(14, 45, 0), true, "Slot 3", new TimeOnly(12, 30, 0) },
                    { 4, new TimeOnly(17, 15, 0), true, "Slot 4", new TimeOnly(15, 0, 0) },
                    { 5, new TimeOnly(19, 45, 0), true, "Slot 5", new TimeOnly(17, 30, 0) },
                    { 6, new TimeOnly(21, 0, 0), true, "Slot 6", new TimeOnly(19, 30, 0) }
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "FacilityID", "CampusID", "Capacity", "CreatedAt", "Description", "FacilityName", "ImageURL", "Status", "TypeID" },
                values: new object[,]
                {
                    { 1, 1, 40, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phòng Lab AI với 40 PC Gaming", "Lab AI - Room 302", null, "Available", 2 },
                    { 2, 1, 200, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hội trường lớn cho sự kiện", "Hội trường Beta", null, "Available", 3 },
                    { 3, 1, 40, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phòng học tiêu chuẩn", "Phòng học  - Room 300", null, "Available", 1 },
                    { 4, 1, 200, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sân bóng đá mini cho sinh viên", "Sân bóng đá mini", null, "Available", 4 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "CreatedAt", "Email", "FullName", "IsActive", "PasswordHash", "PhoneNumber", "RoleID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@fpt.edu.vn", "Nguyễn Quản Trị", true, "123456", "0901234567", 1 },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin_room@fpt.edu.vn", "Lê Duyệt Phòng", true, "123456", "0909999888", 2 },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "student@fpt.edu.vn", "Trần Sinh Viên", true, "123456", "0912345678", 3 },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lecturer@fpt.edu.vn", "Phạm Giảng Viên", true, "123456", "0987654321", 4 },
                    { 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "security@fpt.edu.vn", "Chú Bảo Vệ", true, "123456", "0900000001", 6 },
                    { 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "s1", "Sinh vien 1", true, "1", "0900000002", 3 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingID", "ApprovedAt", "ApproverID", "BookingDate", "BookingType", "CreatedAt", "FacilityID", "PriorityLevel", "Purpose", "RecurrenceGroupID", "RejectionReason", "SlotID", "Status", "UpdatedAt", "UpdatedBy", "UserID" },
                values: new object[,]
                {
                    { 1, null, null, new DateOnly(2025, 12, 18), "Individual", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Low", "Học nhóm Java", null, null, 1, "Approved", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3 },
                    { 2, null, null, new DateOnly(2025, 12, 19), "Individual", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "High", "Hội thảo Tech", null, null, 2, "Pending", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4 }
                });

            migrationBuilder.InsertData(
                table: "FacilityAssets",
                columns: new[] { "ID", "AssetID", "Condition", "FacilityID", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "Tốt", 1, 1 },
                    { 2, 2, "Tốt", 1, 40 },
                    { 3, 4, "Tốt", 1, 2 },
                    { 4, 1, "Tốt", 2, 2 },
                    { 5, 3, "Tốt", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "NotificationID", "CreatedAt", "IsRead", "Message", "Title", "Type", "UserID" },
                values: new object[] { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Yêu cầu Slot 1 hôm nay đã được duyệt.", "Đặt phòng thành công", "Booking", 3 });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportID", "BookingID", "CreatedAt", "Description", "FacilityID", "ReportType", "ResolvedAt", "Status", "Title", "UserID" },
                values: new object[] { 1, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đang code thì bị tắt máy", 1, "Hỏng thiết bị", null, "Pending", "PC số 05 bị màn hình xanh", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ApproverID",
                table: "Bookings",
                column: "ApproverID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FacilityID",
                table: "Bookings",
                column: "FacilityID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_SlotID",
                table: "Bookings",
                column: "SlotID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UpdatedBy",
                table: "Bookings",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserID",
                table: "Bookings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_CampusID",
                table: "Facilities",
                column: "CampusID");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_TypeID",
                table: "Facilities",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityAssets_AssetID",
                table: "FacilityAssets",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityAssets_FacilityID",
                table: "FacilityAssets",
                column: "FacilityID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserID",
                table: "Notifications",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_BookingID",
                table: "Reports",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_FacilityID",
                table: "Reports",
                column: "FacilityID");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UserID",
                table: "Reports",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "UQ__Roles__8A2B61605F36FFA0",
                table: "Roles",
                column: "RoleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SecurityTasks_AssignedToUserId",
                table: "SecurityTasks",
                column: "AssignedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityTasks_CreatedBy",
                table: "SecurityTasks",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D105348CD2578C",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilityAssets");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "SecurityTasks");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "Slots");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Campuses");

            migrationBuilder.DropTable(
                name: "FacilityTypes");
        }
    }
}
