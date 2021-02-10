using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWatchListCore.Migrations
{
    public partial class Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Role",
            //    table: "Users");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 1, "0d5901eb-094c-4e91-877f-94f1f7b58943", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 2, "9ef50e8c-7f66-46fb-8774-bae185f7bf30", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 97, 152, 170, 109, 61, 255, 202, 252, 25, 73, 247, 74, 254, 213, 212, 190, 37, 136, 30, 35, 103, 225, 27, 135, 0, 91, 40, 103, 39, 195, 105, 243, 88, 44, 246, 149, 17, 239, 84, 80, 231, 229, 6, 14, 192, 251, 164, 109, 228, 186, 147, 36, 86, 115, 72, 133, 237, 22, 14, 142, 92, 96, 176, 111 }, new byte[] { 194, 24, 115, 126, 1, 157, 168, 80, 116, 131, 94, 214, 119, 214, 130, 160, 210, 232, 140, 62, 241, 62, 47, 82, 75, 37, 120, 84, 251, 43, 44, 39, 128, 166, 85, 171, 48, 2, 171, 114, 237, 233, 174, 33, 194, 231, 168, 3, 189, 105, 106, 204, 158, 179, 202, 83, 230, 248, 211, 105, 21, 187, 35, 30, 16, 219, 80, 10, 117, 86, 51, 163, 187, 171, 18, 109, 167, 218, 119, 210, 42, 208, 67, 204, 19, 61, 19, 122, 91, 133, 230, 78, 181, 176, 63, 114, 36, 125, 219, 0, 246, 138, 70, 68, 86, 53, 114, 238, 254, 153, 133, 145, 88, 209, 149, 234, 175, 30, 166, 146, 69, 202, 118, 236, 225, 106, 180, 123 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

           /* migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "TEXT",
                nullable: true);
                */
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 250, 153, 208, 248, 230, 209, 63, 80, 5, 168, 197, 49, 105, 18, 33, 104, 42, 133, 52, 228, 136, 105, 88, 4, 43, 179, 73, 116, 222, 218, 141, 156, 44, 236, 144, 119, 18, 135, 244, 91, 92, 96, 196, 40, 212, 117, 184, 146, 27, 130, 88, 191, 118, 23, 113, 177, 106, 121, 131, 59, 185, 60, 131, 123 }, new byte[] { 59, 176, 198, 9, 255, 39, 207, 118, 166, 184, 83, 187, 67, 250, 190, 84, 180, 35, 82, 48, 73, 131, 139, 60, 91, 243, 50, 57, 184, 247, 195, 133, 240, 91, 13, 117, 94, 237, 126, 147, 99, 38, 58, 189, 4, 91, 228, 4, 193, 30, 252, 47, 68, 57, 122, 25, 23, 227, 183, 131, 82, 100, 217, 81, 49, 187, 12, 213, 33, 231, 196, 93, 126, 116, 37, 90, 18, 34, 31, 62, 171, 20, 99, 150, 115, 205, 211, 166, 135, 127, 89, 216, 207, 152, 106, 73, 215, 222, 252, 175, 12, 209, 8, 102, 165, 22, 41, 116, 74, 3, 74, 196, 94, 242, 57, 152, 209, 85, 137, 147, 85, 80, 79, 179, 113, 226, 146, 55 } });
        }
    }
}
