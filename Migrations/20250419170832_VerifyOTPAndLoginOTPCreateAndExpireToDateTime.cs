using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MizanGraduationProject.Migrations
{
    /// <inheritdoc />
    public partial class VerifyOTPAndLoginOTPCreateAndExpireToDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredAt",
                table: "VerifyOTPs",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "DATEADD(minute, 10, GETDATE())",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValueSql: "DATEADD(minute, 10, GETDATE())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "VerifyOTPs",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredAt",
                table: "LoginOTPs",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "DATEADD(minute, 10, GETDATE())",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValueSql: "DATEADD(minute, 10, GETDATE())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "LoginOTPs",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValueSql: "getdate()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExpiredAt",
                table: "VerifyOTPs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "DATEADD(minute, 10, GETDATE())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "DATEADD(minute, 10, GETDATE())");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedAt",
                table: "VerifyOTPs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "ExpiredAt",
                table: "LoginOTPs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "DATEADD(minute, 10, GETDATE())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "DATEADD(minute, 10, GETDATE())");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedAt",
                table: "LoginOTPs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");
        }
    }
}
