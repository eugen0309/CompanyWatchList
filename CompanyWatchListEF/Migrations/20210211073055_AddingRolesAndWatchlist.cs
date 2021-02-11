using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWatchListCore.Migrations
{
    public partial class AddingRolesAndWatchlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");*/

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

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
                name: "UserWatchlists",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWatchlists", x => new { x.UserId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_UserWatchlists_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWatchlists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                values: new object[] { 1, "98566893-4561-4098-bdb7-ae2cb177c650", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 2, "2b579ea8-6204-43ac-b8a9-d423770dbd25", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 52, 223, 125, 102, 8, 60, 231, 204, 180, 146, 188, 99, 176, 43, 247, 37, 37, 136, 140, 65, 254, 239, 11, 118, 190, 194, 130, 198, 107, 11, 173, 236, 47, 32, 135, 100, 252, 252, 77, 76, 132, 118, 66, 242, 216, 203, 229, 197, 13, 48, 148, 4, 152, 90, 117, 67, 159, 217, 101, 252, 152, 152, 241, 131 }, new byte[] { 252, 36, 215, 78, 58, 165, 144, 216, 252, 170, 96, 174, 14, 68, 127, 89, 236, 249, 36, 205, 172, 231, 123, 213, 84, 60, 232, 137, 171, 87, 103, 149, 6, 80, 22, 127, 44, 79, 45, 133, 160, 136, 254, 38, 190, 27, 228, 30, 159, 96, 32, 205, 67, 11, 89, 59, 10, 89, 240, 12, 43, 9, 205, 197, 31, 120, 29, 240, 122, 140, 126, 104, 174, 81, 236, 40, 224, 76, 255, 171, 118, 252, 239, 241, 142, 221, 191, 17, 124, 149, 225, 143, 85, 199, 171, 81, 164, 169, 171, 12, 174, 189, 218, 221, 245, 188, 191, 22, 154, 251, 66, 84, 49, 14, 210, 235, 140, 150, 253, 59, 43, 226, 200, 165, 224, 206, 167, 131 } });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWatchlists_CompanyId",
                table: "UserWatchlists",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserWatchlists");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 250, 153, 208, 248, 230, 209, 63, 80, 5, 168, 197, 49, 105, 18, 33, 104, 42, 133, 52, 228, 136, 105, 88, 4, 43, 179, 73, 116, 222, 218, 141, 156, 44, 236, 144, 119, 18, 135, 244, 91, 92, 96, 196, 40, 212, 117, 184, 146, 27, 130, 88, 191, 118, 23, 113, 177, 106, 121, 131, 59, 185, 60, 131, 123 }, new byte[] { 59, 176, 198, 9, 255, 39, 207, 118, 166, 184, 83, 187, 67, 250, 190, 84, 180, 35, 82, 48, 73, 131, 139, 60, 91, 243, 50, 57, 184, 247, 195, 133, 240, 91, 13, 117, 94, 237, 126, 147, 99, 38, 58, 189, 4, 91, 228, 4, 193, 30, 252, 47, 68, 57, 122, 25, 23, 227, 183, 131, 82, 100, 217, 81, 49, 187, 12, 213, 33, 231, 196, 93, 126, 116, 37, 90, 18, 34, 31, 62, 171, 20, 99, 150, 115, 205, 211, 166, 135, 127, 89, 216, 207, 152, 106, 73, 215, 222, 252, 175, 12, 209, 8, 102, 165, 22, 41, 116, 74, 3, 74, 196, 94, 242, 57, 152, 209, 85, 137, 147, 85, 80, 79, 179, 113, 226, 146, 55 } });
        }
    }
}
