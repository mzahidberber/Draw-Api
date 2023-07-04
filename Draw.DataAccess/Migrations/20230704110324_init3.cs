using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Draw.DataAccess.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8af64394-cf77-41ae-aed4-1de81fa67406");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9957f936-7f7f-4356-81e1-74d3ca5ce2e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb833f92-e6a9-4039-8838-fdfb7056f0f4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "115d708d-6c9f-449b-876b-6166d17f7109", "56bc7f8f-3ae7-4d57-9ccd-e159a20a2566", "manager", "MANAGER" },
                    { "30744922-3bb8-412c-a9c3-18284376d610", "7febc1c4-023b-4956-a453-fac0038f6e37", "user", "USER" },
                    { "3c0329ec-619a-414b-88c8-1c7301428cfc", "b4103668-cf75-4335-9d8d-52c531d2c57d", "admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 120,
                column: "Body",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "115d708d-6c9f-449b-876b-6166d17f7109");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30744922-3bb8-412c-a9c3-18284376d610");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c0329ec-619a-414b-88c8-1c7301428cfc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8af64394-cf77-41ae-aed4-1de81fa67406", "8c1546bd-cb9e-42c7-86a5-afcd46e07075", "user", "USER" },
                    { "9957f936-7f7f-4356-81e1-74d3ca5ce2e0", "8dbe362b-da0b-48cd-9e3f-b1250c31f8e4", "manager", "MANAGER" },
                    { "eb833f92-e6a9-4039-8838-fdfb7056f0f4", "212645a0-0e13-4af8-9eed-aef30ba3889c", "admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 120,
                column: "Body",
                value: "getuser.json");
        }
    }
}
