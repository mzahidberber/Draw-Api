using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Draw.DataAccess.Migrations
{
    public partial class addDrawBoxTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40bf6022-ed61-4c00-8b91-4123315cec3d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e342925b-6860-4c6b-80c0-9c4d23b3e838");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe108175-059b-4e1d-918f-87fc6917c08b");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Draws",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditTime",
                table: "Draws",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "82ae8948-baae-455f-9553-d8c69783fda8", "d6a98947-5031-458e-b30c-d701df77a93b", "admin", "ADMIN" },
                    { "8dfe1972-6fa1-47b7-bca8-4b74d4fdee6c", "10130d8f-05d4-487d-8e05-02d2731772b1", "user", "USER" },
                    { "ef399049-a6e9-447f-89da-4102cb87dd41", "d5f26847-d66e-4a3d-858f-509b1f1ee339", "manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b21972e1-742f-4fa7-be46-1189d9cab7ca",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6db82ef6-404c-4a85-a0db-e1f8fa1e4799", "874e8d4d-7bed-409e-84ce-2044304b810f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b21972e1-742f-4fa7-be46-1189d9cab7cb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "839a799a-c186-4a2e-89c6-93b37f82fc16", "88a24320-0f83-429c-aff4-1bb1900efb5c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b21972e1-742f-4fa7-be46-1189d9cab7cc",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8601be2d-15a4-4046-89d7-716d7950fe3f", "99a311f6-ae36-46b2-9f6f-730363c9f626" });

            migrationBuilder.UpdateData(
                table: "Draws",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateTime", "EditTime" },
                values: new object[] { new DateTime(2023, 5, 9, 8, 41, 48, 35, DateTimeKind.Utc).AddTicks(3318), new DateTime(2023, 5, 9, 8, 41, 48, 35, DateTimeKind.Utc).AddTicks(3323) });

            migrationBuilder.UpdateData(
                table: "Draws",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateTime", "EditTime" },
                values: new object[] { new DateTime(2023, 5, 9, 8, 41, 48, 35, DateTimeKind.Utc).AddTicks(3330), new DateTime(2023, 5, 9, 8, 41, 48, 35, DateTimeKind.Utc).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "Draws",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateTime", "EditTime" },
                values: new object[] { new DateTime(2023, 5, 9, 8, 41, 48, 35, DateTimeKind.Utc).AddTicks(3332), new DateTime(2023, 5, 9, 8, 41, 48, 35, DateTimeKind.Utc).AddTicks(3332) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82ae8948-baae-455f-9553-d8c69783fda8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dfe1972-6fa1-47b7-bca8-4b74d4fdee6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef399049-a6e9-447f-89da-4102cb87dd41");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Draws");

            migrationBuilder.DropColumn(
                name: "EditTime",
                table: "Draws");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "40bf6022-ed61-4c00-8b91-4123315cec3d", "db256b4b-b628-43ae-964e-ef1069799023", "manager", "MANAGER" },
                    { "e342925b-6860-4c6b-80c0-9c4d23b3e838", "4af84c8d-d9ae-482b-9c30-49d962991bc8", "user", "USER" },
                    { "fe108175-059b-4e1d-918f-87fc6917c08b", "e3451ba0-72c5-48e3-8e9e-f73a2cb7e587", "admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b21972e1-742f-4fa7-be46-1189d9cab7ca",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ceeb780b-f3a5-4c76-9d2b-402b13eb4899", "db4bc67f-528a-4520-a81e-cb35044e76ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b21972e1-742f-4fa7-be46-1189d9cab7cb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9ed1353f-a4ee-44c4-ad8f-6d6edd7404d3", "7ef43a44-63e4-49c5-b6a5-f163c9f09ea5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b21972e1-742f-4fa7-be46-1189d9cab7cc",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d2a9ae78-7530-49cc-b2a9-32b94e1cb5ba", "387b2563-f6c5-4621-8a7e-42c95174e056" });
        }
    }
}
