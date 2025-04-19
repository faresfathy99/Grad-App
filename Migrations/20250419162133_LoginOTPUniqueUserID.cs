using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MizanGraduationProject.Migrations
{
    /// <inheritdoc />
    public partial class LoginOTPUniqueUserID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LoginOTPs_UserID",
                table: "LoginOTPs");

            migrationBuilder.CreateIndex(
                name: "IX_LoginOTPs_UserID",
                table: "LoginOTPs",
                column: "UserID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LoginOTPs_UserID",
                table: "LoginOTPs");

            migrationBuilder.CreateIndex(
                name: "IX_LoginOTPs_UserID",
                table: "LoginOTPs",
                column: "UserID");
        }
    }
}
