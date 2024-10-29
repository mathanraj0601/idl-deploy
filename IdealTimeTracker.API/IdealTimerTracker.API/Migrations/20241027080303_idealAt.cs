using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdealTImeTracker.API.Migrations
{
    public partial class idealAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "IdealAt",
                table: "UserLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createdOn", "modifiedOn" },
                values: new object[] { new DateTime(2024, 10, 27, 13, 33, 2, 845, DateTimeKind.Local).AddTicks(30), new DateTime(2024, 10, 27, 13, 33, 2, 845, DateTimeKind.Local).AddTicks(15) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "createdOn", "modifiedOn" },
                values: new object[] { new DateTime(2024, 10, 27, 13, 33, 2, 845, DateTimeKind.Local).AddTicks(35), new DateTime(2024, 10, 27, 13, 33, 2, 845, DateTimeKind.Local).AddTicks(33) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdealAt",
                table: "UserLogs");

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
    }
}
