using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdealTImeTracker.API.Migrations
{
    public partial class createdmodifiedoncontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createdOn", "modifiedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "createdOn", "modifiedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
