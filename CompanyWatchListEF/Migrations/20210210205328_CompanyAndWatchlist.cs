using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWatchListCore.Migrations
{
    public partial class CompanyAndWatchlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_UserId",
                table: "UserRoles");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7b8da9a4-e331-4a03-8cc0-a2a301b8bdb3");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "741cc9fa-a919-43a0-9180-fb6290ffaf69");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 135, 135, 56, 235, 103, 9, 84, 205, 234, 201, 180, 49, 3, 3, 249, 117, 137, 26, 59, 38, 152, 87, 52, 232, 207, 109, 94, 241, 126, 95, 206, 17, 100, 254, 30, 138, 219, 196, 53, 207, 50, 135, 79, 31, 79, 115, 1, 138, 55, 102, 51, 10, 170, 176, 108, 49, 40, 66, 157, 42, 112, 202, 10, 166 }, new byte[] { 126, 112, 64, 153, 138, 152, 222, 196, 111, 253, 2, 71, 222, 179, 208, 253, 105, 113, 63, 205, 69, 96, 81, 63, 15, 137, 204, 65, 205, 115, 109, 251, 239, 253, 7, 190, 181, 234, 86, 126, 169, 111, 92, 22, 249, 135, 120, 121, 152, 112, 31, 224, 81, 85, 219, 15, 255, 59, 43, 139, 139, 71, 82, 84, 127, 254, 178, 236, 240, 18, 189, 174, 162, 130, 236, 29, 103, 229, 100, 22, 52, 88, 149, 201, 23, 100, 73, 162, 59, 230, 245, 126, 95, 89, 162, 100, 125, 154, 2, 241, 211, 130, 203, 235, 196, 135, 183, 36, 44, 15, 31, 164, 7, 132, 254, 57, 129, 247, 38, 141, 32, 151, 201, 223, 119, 4, 137, 53 } });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f3710b8f-c339-422c-92dc-4f5e89a0ff5e");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "87c3241d-1b52-4808-b8ae-f5f643c891e3");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 93, 142, 79, 186, 99, 103, 216, 102, 72, 61, 61, 170, 188, 12, 106, 230, 30, 150, 146, 42, 14, 54, 146, 250, 222, 209, 86, 13, 171, 31, 17, 98, 237, 215, 12, 174, 104, 51, 153, 117, 200, 157, 191, 79, 199, 52, 169, 131, 210, 188, 135, 85, 198, 140, 138, 74, 166, 49, 95, 13, 240, 117, 238, 74 }, new byte[] { 31, 107, 116, 29, 65, 183, 227, 96, 112, 170, 69, 112, 217, 55, 56, 10, 95, 5, 26, 159, 194, 109, 110, 8, 71, 63, 217, 196, 200, 255, 81, 35, 133, 107, 143, 232, 21, 5, 18, 171, 78, 180, 107, 186, 227, 84, 62, 244, 239, 214, 68, 7, 94, 64, 184, 245, 242, 22, 72, 123, 128, 49, 64, 68, 105, 92, 16, 72, 222, 39, 239, 71, 132, 229, 99, 18, 168, 65, 131, 42, 123, 145, 120, 83, 138, 8, 130, 15, 159, 15, 175, 121, 203, 99, 203, 100, 221, 143, 222, 209, 66, 83, 130, 72, 170, 138, 30, 199, 37, 35, 46, 241, 84, 122, 148, 183, 89, 12, 193, 232, 146, 249, 2, 225, 245, 250, 105, 159 } });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
