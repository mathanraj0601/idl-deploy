using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdealTImeTracker.API.Migrations
{
    public partial class idealAtnullv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "createdOn", "modifiedOn" },
                values: new object[] { new DateTime(2024, 10, 27, 13, 34, 54, 3, DateTimeKind.Local).AddTicks(6624), new DateTime(2024, 10, 27, 13, 34, 54, 3, DateTimeKind.Local).AddTicks(6606) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "createdOn", "modifiedOn" },
                values: new object[] { new DateTime(2024, 10, 27, 13, 34, 54, 3, DateTimeKind.Local).AddTicks(6631), new DateTime(2024, 10, 27, 13, 34, 54, 3, DateTimeKind.Local).AddTicks(6629) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
