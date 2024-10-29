using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdealTImeTracker.API.Migrations
{
    public partial class shiftlogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "UserActivities",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Activity", "CountPerDay", "DurationInMins" },
                values: new object[] { "ShiftLogin", null, 0 });

            migrationBuilder.InsertData(
                table: "UserActivities",
                columns: new[] { "Id", "Activity", "CountPerDay", "DurationInMins", "IsActive" },
                values: new object[,]
                {
                    { 7, "tea break", 2, 15, true },
                    { 8, "lunch break", 2, 30, true }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createdOn", "modifiedOn" },
                values: new object[] { new DateTime(2024, 10, 27, 11, 55, 35, 648, DateTimeKind.Local).AddTicks(5881), new DateTime(2024, 10, 27, 11, 55, 35, 648, DateTimeKind.Local).AddTicks(5867) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "createdOn", "modifiedOn" },
                values: new object[] { new DateTime(2024, 10, 27, 11, 55, 35, 648, DateTimeKind.Local).AddTicks(5887), new DateTime(2024, 10, 27, 11, 55, 35, 648, DateTimeKind.Local).AddTicks(5885) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserActivities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "UserActivities",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Activity", "CountPerDay", "DurationInMins" },
                values: new object[] { "tea break", 2, 15 });

            migrationBuilder.InsertData(
                table: "UserActivities",
                columns: new[] { "Id", "Activity", "CountPerDay", "DurationInMins", "IsActive" },
                values: new object[] { 6, "lunch break", 2, 30, true });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createdOn", "modifiedOn" },
                values: new object[] { new DateTime(2024, 10, 12, 15, 58, 28, 262, DateTimeKind.Local).AddTicks(7015), new DateTime(2024, 10, 12, 15, 58, 28, 262, DateTimeKind.Local).AddTicks(7001) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "createdOn", "modifiedOn" },
                values: new object[] { new DateTime(2024, 10, 12, 15, 58, 28, 262, DateTimeKind.Local).AddTicks(7021), new DateTime(2024, 10, 12, 15, 58, 28, 262, DateTimeKind.Local).AddTicks(7019) });
        }
    }
}
