using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MR.TaskTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "DateCreated", "DateModified", "Email", "FirstName", "LastName", "Password", "ReportsToId", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 14, 10, 40, 33, 484, DateTimeKind.Local).AddTicks(1170), new DateTime(2024, 7, 14, 10, 40, 33, 484, DateTimeKind.Local).AddTicks(1200), "admin@mr.tasktracker.com", "A Dhaval", "Kanani", "$2a$11$ZxHBUyn3Zd9LV.hPvDj1G.KaxpVmIDRwuX2L3G3Glqq4y8Ynk3qlq", 1, "ADMIN", "admin@mr.tasktracker.com" },
                    { 2, new DateTime(2024, 7, 14, 10, 40, 33, 484, DateTimeKind.Local).AddTicks(1200), new DateTime(2024, 7, 14, 10, 40, 33, 484, DateTimeKind.Local).AddTicks(1200), "user1@mr.tasktracker.com", "U1 Dhaval", "Kanani", "$2a$11$ZxHBUyn3Zd9LV.hPvDj1G.KaxpVmIDRwuX2L3G3Glqq4y8Ynk3qlq", 1, "EMPLOYEE", "user1@mr.tasktracker.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
