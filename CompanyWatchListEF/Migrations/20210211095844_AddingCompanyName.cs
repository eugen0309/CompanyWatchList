using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWatchListCore.Migrations
{
    public partial class AddingCompanyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Companies",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "2921fced-95aa-456e-b471-492e151e11b9");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "ac29b737-4834-4dc5-a915-703955cc223c");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 2, 147, 212, 4, 118, 43, 75, 64, 8, 12, 229, 211, 56, 99, 59, 16, 88, 118, 208, 43, 216, 19, 168, 39, 175, 237, 44, 184, 140, 177, 238, 171, 235, 21, 36, 245, 241, 78, 106, 44, 43, 61, 19, 112, 255, 163, 57, 246, 159, 75, 136, 26, 243, 170, 201, 31, 126, 42, 89, 7, 203, 22, 132, 128 }, new byte[] { 12, 153, 20, 134, 170, 171, 165, 140, 20, 130, 125, 143, 140, 21, 46, 109, 160, 214, 38, 162, 239, 176, 41, 185, 177, 251, 151, 69, 219, 219, 60, 41, 170, 152, 207, 251, 56, 70, 230, 216, 162, 4, 112, 110, 223, 111, 1, 101, 255, 219, 199, 17, 76, 250, 253, 104, 209, 67, 190, 92, 14, 165, 66, 176, 97, 124, 83, 173, 84, 28, 152, 81, 214, 214, 8, 27, 140, 71, 168, 23, 48, 102, 80, 97, 167, 49, 211, 119, 229, 247, 84, 234, 233, 247, 224, 171, 74, 216, 6, 248, 236, 249, 185, 160, 48, 95, 250, 44, 112, 16, 51, 17, 213, 91, 189, 175, 93, 154, 131, 248, 36, 153, 134, 35, 158, 144, 16, 124 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Companies");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "98566893-4561-4098-bdb7-ae2cb177c650");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "2b579ea8-6204-43ac-b8a9-d423770dbd25");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 52, 223, 125, 102, 8, 60, 231, 204, 180, 146, 188, 99, 176, 43, 247, 37, 37, 136, 140, 65, 254, 239, 11, 118, 190, 194, 130, 198, 107, 11, 173, 236, 47, 32, 135, 100, 252, 252, 77, 76, 132, 118, 66, 242, 216, 203, 229, 197, 13, 48, 148, 4, 152, 90, 117, 67, 159, 217, 101, 252, 152, 152, 241, 131 }, new byte[] { 252, 36, 215, 78, 58, 165, 144, 216, 252, 170, 96, 174, 14, 68, 127, 89, 236, 249, 36, 205, 172, 231, 123, 213, 84, 60, 232, 137, 171, 87, 103, 149, 6, 80, 22, 127, 44, 79, 45, 133, 160, 136, 254, 38, 190, 27, 228, 30, 159, 96, 32, 205, 67, 11, 89, 59, 10, 89, 240, 12, 43, 9, 205, 197, 31, 120, 29, 240, 122, 140, 126, 104, 174, 81, 236, 40, 224, 76, 255, 171, 118, 252, 239, 241, 142, 221, 191, 17, 124, 149, 225, 143, 85, 199, 171, 81, 164, 169, 171, 12, 174, 189, 218, 221, 245, 188, 191, 22, 154, 251, 66, 84, 49, 14, 210, 235, 140, 150, 253, 59, 43, 226, 200, 165, 224, 206, 167, 131 } });
        }
    }
}
