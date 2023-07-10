using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Draw.DataAccess.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cbce9ec-3ed7-48e6-b902-5da1a7e596d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b17c7a04-9413-4a4a-a905-cf39201eed48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8643afa-f925-4127-adf4-e84f55381838");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d9d48a0-978f-417f-ab16-2f98f3bc4274", "70c64296-a1ea-4a51-b494-4631b1a8c2a3", "admin", "ADMIN" },
                    { "79bedb41-6c58-4f04-bc05-bae2930110b7", "b4c7105d-67e5-40d9-be02-3bb156f5ec54", "manager", "MANAGER" },
                    { "8384df53-228f-4d07-9ac4-9003c30f017e", "4a90296f-8ed7-4780-858e-cb844284e423", "user", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 59,
                column: "TextUrl1",
                value: "Layert.html");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 64,
                column: "TextUrl1",
                value: "Pent.html");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 70,
                column: "TextUrl1",
                value: "Penstylet.html");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 81,
                column: "TextUrl1",
                value: "Pointt.html");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 86,
                column: "Body",
                value: "pointtypeadd.json");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 90,
                column: "Body",
                value: "radiusesadd.json");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 93,
                column: "TextUrl1",
                value: "Radiuset.html");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 94,
                column: "TextUrl1",
                value: "SSAnglet.html");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d9d48a0-978f-417f-ab16-2f98f3bc4274");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79bedb41-6c58-4f04-bc05-bae2930110b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8384df53-228f-4d07-9ac4-9003c30f017e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3cbce9ec-3ed7-48e6-b902-5da1a7e596d3", "be8483ca-b41a-4ce6-9b65-6ecb3aeaa867", "admin", "ADMIN" },
                    { "b17c7a04-9413-4a4a-a905-cf39201eed48", "1ecb62a5-ae5f-4b9c-b1f8-9412daf9db3c", "user", "USER" },
                    { "f8643afa-f925-4127-adf4-e84f55381838", "0ec85bd6-4a46-45ad-b10f-c60c3a9042e5", "manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 59,
                column: "TextUrl1",
                value: "Layer.html");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 64,
                column: "TextUrl1",
                value: "Pen.html");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 70,
                column: "TextUrl1",
                value: "Penstyle.html");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 81,
                column: "TextUrl1",
                value: "Point.html");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 86,
                column: "Body",
                value: "pointtypeadd");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 90,
                column: "Body",
                value: "radiusesadd");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 93,
                column: "TextUrl1",
                value: "Radiuse.html");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 94,
                column: "TextUrl1",
                value: "SSAngle.html");
        }
    }
}
