using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdealTImeTracker.API.Migrations
{
    public partial class idealAtnull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "IdealAt",
                table: "UserLogs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createdOn", "modifiedOn" },
                values: new object[] { new DateTime(2024, 10, 27, 13, 33, 13, 210, DateTimeKind.Local).AddTicks(1890), new DateTime(2024, 10, 27, 13, 33, 13, 210, DateTimeKind.Local).AddTicks(1873) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "createdOn", "modifiedOn" },
                values: new object[] { new DateTime(2024, 10, 27, 13, 33, 13, 210, DateTimeKind.Local).AddTicks(1895), new DateTime(2024, 10, 27, 13, 33, 13, 210, DateTimeKind.Local).AddTicks(1894) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "IdealAt",
                table: "UserLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
    }
}
