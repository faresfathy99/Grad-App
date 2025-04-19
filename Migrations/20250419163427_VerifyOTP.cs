using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MizanGraduationProject.Migrations
{
    /// <inheritdoc />
    public partial class VerifyOTP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VerifyOTPs",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "getdate()"),
                    ExpiredAt = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "DATEADD(minute, 10, GETDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerifyOTPs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VerifyOTPs_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VerifyOTPs_UserID",
                table: "VerifyOTPs",
                column: "UserID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerifyOTPs");
        }
    }
}
