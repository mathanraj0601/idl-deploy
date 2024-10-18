using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdealTImeTracker.API.Migrations
{
    public partial class updatemanagerreporting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLogs_Users_EmpId",
                table: "UserLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_ReportingTo",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ReportingTo",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserLogs_EmpId",
                table: "UserLogs");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "EmpId",
                keyValue: "ADMIN");

            migrationBuilder.AlterColumn<string>(
                name: "ReportingTo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmpId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "EmpId",
                table: "UserLogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "EmpId", "IsActive", "Name", "PassWord", "ReportingTo", "Role" },
                values: new object[] { 1, "admin@example.com", "ADMIN", true, "Admin User", "ADMIN", null, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "EmpId", "IsActive", "Name", "PassWord", "ReportingTo", "Role" },
                values: new object[] { 2, "supermanager@example.com", "SUPERMANAGER", true, "Super manager User", "SUPERMANAGER", null, "manager" });

            migrationBuilder.CreateIndex(
                name: "IX_UserLogs_UserId",
                table: "UserLogs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogs_Users_UserId",
                table: "UserLogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLogs_Users_UserId",
                table: "UserLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserLogs_UserId",
                table: "UserLogs");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserLogs");

            migrationBuilder.AlterColumn<string>(
                name: "ReportingTo",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmpId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmpId",
                table: "UserLogs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ReportingTo",
                table: "Users",
                column: "ReportingTo");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogs_EmpId",
                table: "UserLogs",
                column: "EmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogs_Users_EmpId",
                table: "UserLogs",
                column: "EmpId",
                principalTable: "Users",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_ReportingTo",
                table: "Users",
                column: "ReportingTo",
                principalTable: "Users",
                principalColumn: "EmpId");
        }
    }
}
