using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWatchList.Migrations
{
    public partial class AddingInitialAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 93, 142, 79, 186, 99, 103, 216, 102, 72, 61, 61, 170, 188, 12, 106, 230, 30, 150, 146, 42, 14, 54, 146, 250, 222, 209, 86, 13, 171, 31, 17, 98, 237, 215, 12, 174, 104, 51, 153, 117, 200, 157, 191, 79, 199, 52, 169, 131, 210, 188, 135, 85, 198, 140, 138, 74, 166, 49, 95, 13, 240, 117, 238, 74 }, new byte[] { 31, 107, 116, 29, 65, 183, 227, 96, 112, 170, 69, 112, 217, 55, 56, 10, 95, 5, 26, 159, 194, 109, 110, 8, 71, 63, 217, 196, 200, 255, 81, 35, 133, 107, 143, 232, 21, 5, 18, 171, 78, 180, 107, 186, 227, 84, 62, 244, 239, 214, 68, 7, 94, 64, 184, 245, 242, 22, 72, 123, 128, 49, 64, 68, 105, 92, 16, 72, 222, 39, 239, 71, 132, 229, 99, 18, 168, 65, 131, 42, 123, 145, 120, 83, 138, 8, 130, 15, 159, 15, 175, 121, 203, 99, 203, 100, 221, 143, 222, 209, 66, 83, 130, 72, 170, 138, 30, 199, 37, 35, 46, 241, 84, 122, 148, 183, 89, 12, 193, 232, 146, 249, 2, 225, 245, 250, 105, 159 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "0d5901eb-094c-4e91-877f-94f1f7b58943");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "9ef50e8c-7f66-46fb-8774-bae185f7bf30");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 97, 152, 170, 109, 61, 255, 202, 252, 25, 73, 247, 74, 254, 213, 212, 190, 37, 136, 30, 35, 103, 225, 27, 135, 0, 91, 40, 103, 39, 195, 105, 243, 88, 44, 246, 149, 17, 239, 84, 80, 231, 229, 6, 14, 192, 251, 164, 109, 228, 186, 147, 36, 86, 115, 72, 133, 237, 22, 14, 142, 92, 96, 176, 111 }, new byte[] { 194, 24, 115, 126, 1, 157, 168, 80, 116, 131, 94, 214, 119, 214, 130, 160, 210, 232, 140, 62, 241, 62, 47, 82, 75, 37, 120, 84, 251, 43, 44, 39, 128, 166, 85, 171, 48, 2, 171, 114, 237, 233, 174, 33, 194, 231, 168, 3, 189, 105, 106, 204, 158, 179, 202, 83, 230, 248, 211, 105, 21, 187, 35, 30, 16, 219, 80, 10, 117, 86, 51, 163, 187, 171, 18, 109, 167, 218, 119, 210, 42, 208, 67, 204, 19, 61, 19, 122, 91, 133, 230, 78, 181, 176, 63, 114, 36, 125, 219, 0, 246, 138, 70, 68, 86, 53, 114, 238, 254, 153, 133, 145, 88, 209, 149, 234, 175, 30, 166, 146, 69, 202, 118, 236, 225, 106, 180, 123 } });
        }
    }
}
