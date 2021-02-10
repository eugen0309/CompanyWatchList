using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWatchListCore.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Token", "UserName" },
                values: new object[] { 1, "Eugen", "Stancioiu", new byte[] { 250, 153, 208, 248, 230, 209, 63, 80, 5, 168, 197, 49, 105, 18, 33, 104, 42, 133, 52, 228, 136, 105, 88, 4, 43, 179, 73, 116, 222, 218, 141, 156, 44, 236, 144, 119, 18, 135, 244, 91, 92, 96, 196, 40, 212, 117, 184, 146, 27, 130, 88, 191, 118, 23, 113, 177, 106, 121, 131, 59, 185, 60, 131, 123 }, new byte[] { 59, 176, 198, 9, 255, 39, 207, 118, 166, 184, 83, 187, 67, 250, 190, 84, 180, 35, 82, 48, 73, 131, 139, 60, 91, 243, 50, 57, 184, 247, 195, 133, 240, 91, 13, 117, 94, 237, 126, 147, 99, 38, 58, 189, 4, 91, 228, 4, 193, 30, 252, 47, 68, 57, 122, 25, 23, 227, 183, 131, 82, 100, 217, 81, 49, 187, 12, 213, 33, 231, 196, 93, 126, 116, 37, 90, 18, 34, 31, 62, 171, 20, 99, 150, 115, 205, 211, 166, 135, 127, 89, 216, 207, 152, 106, 73, 215, 222, 252, 175, 12, 209, 8, 102, 165, 22, 41, 116, 74, 3, 74, 196, 94, 242, 57, 152, 209, 85, 137, 147, 85, 80, 79, 179, 113, 226, 146, 55 },  null, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
