using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Draw.DataAccess.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95312bcd-0256-48c4-a6c7-56f2295e4b09");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "954bb0de-c0ba-45ff-91e1-ffbb673a7abd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad5f5093-f21b-4462-b2d3-74aba3affac5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8af64394-cf77-41ae-aed4-1de81fa67406", "8c1546bd-cb9e-42c7-86a5-afcd46e07075", "user", "USER" },
                    { "9957f936-7f7f-4356-81e1-74d3ca5ce2e0", "8dbe362b-da0b-48cd-9e3f-b1250c31f8e4", "manager", "MANAGER" },
                    { "eb833f92-e6a9-4039-8838-fdfb7056f0f4", "212645a0-0e13-4af8-9eed-aef30ba3889c", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "MainTitles",
                columns: new[] { "Id", "Body", "Explanation", "GifUrl", "Header", "IndexId", "LogoUrl", "ResponeseType", "Return", "ShortcutUrl1", "ShortcutUrl2", "ShortcutUrl3", "TextUrl1", "TextUrl2", "TextUrl3", "Title" },
                values: new object[,]
                {
                    { 21, null, null, null, null, 3, null, null, null, null, null, null, "DrawGeo.html", null, null, "DrawGeo" },
                    { 22, null, null, null, null, 3, null, null, null, null, null, null, "Geo.html", null, null, "Geo" },
                    { 23, null, null, null, null, 4, null, null, null, null, null, null, "DrawAuth.html", null, null, "DrawAuth" },
                    { 24, null, null, null, null, 4, null, null, null, null, null, null, "User.html", null, null, "User" },
                    { 25, null, null, null, null, 4, null, null, null, null, null, null, "Auth.html", null, null, "Auth" },
                    { 26, null, null, null, null, 1, null, null, null, null, null, null, "DrawCAD.html", null, null, "DrawCAD" }
                });

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 35,
                column: "Title",
                value: "Elements By Draw With Attributes");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 87,
                column: "Body",
                value: "pointtypedelete.json");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 88,
                column: "Body",
                value: "pointtypeupdate.json");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 91,
                column: "Body",
                value: "radiusesdelete.json");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 92,
                column: "Body",
                value: "radiusesupdate.json");

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "Id", "Body", "Explanation", "GifUrl", "Header", "IndexId", "LogoUrl", "MainTitleId", "ResponeseType", "Return", "ShortcutUrl1", "ShortcutUrl2", "ShortcutUrl3", "TextUrl1", "TextUrl2", "TextUrl3", "Title" },
                values: new object[,]
                {
                    { 99, "findTwoPointsLength.json", null, null, "/findTwoPointsLength/", 3, null, 22, "POST", null, null, null, null, "findTwoPointsLength.html", null, null, "Find Two Point Length" },
                    { 100, "findCenterAndRadius.json", null, null, "/findCenterAndRadius/", 3, null, 22, "POST", null, null, null, null, "findCenterAndRadius.html", null, null, "Find Center And Radius" },
                    { 101, "findToSlopeLine.json", null, null, "/findToSlopeLine/", 3, null, 22, "POST", null, null, null, null, "findToSlopeLine.html", null, null, "Find To Slope Line" },
                    { 102, "findDegreeLineSlope.json", null, null, "/findDegreeLineSlope/", 3, null, 22, "POST", null, null, null, null, "findDegreeLineSlope.html", null, null, "Find Degree Line Slope" },
                    { 103, "findDegreeLineTwoPoints.json", null, null, "/findDegreeLineTwoPoints/", 3, null, 22, "POST", null, null, null, null, "findDegreeLineTwoPoints.html", null, null, "Find Degree Line Two Points" },
                    { 104, "convertDegreeToSlope.json", null, null, "/convertDegreeToSlope/", 3, null, 22, "POST", null, null, null, null, "convertDegreeToSlope.html", null, null, "Convert Degree To Slope" },
                    { 105, "convertRadianToDegree.json", null, null, "/convertRadianToDegree/", 3, null, 22, "POST", null, null, null, null, "convertRadianToDegree.html", null, null, "Convert Radian To Degree" },
                    { 106, "convertDegreeToRadians.json", null, null, "/convertDegreeToRadians/", 3, null, 22, "POST", null, null, null, null, "convertDegreeToRadians.html", null, null, "Convert Degree To Radians" },
                    { 107, "findCenterPointToLine.json", null, null, "/findCenterPointToLine/", 3, null, 22, "POST", null, null, null, null, "findCenterPointToLine.html", null, null, "Find Center Point To Line" },
                    { 108, "findDegreeToBetweenTwoLines.json", null, null, "/findDegreeToBetweenTwoLines/", 3, null, 22, "POST", null, null, null, null, "findDegreeToBetweenTwoLines.html", null, null, "Find Degree To Between Two Lines" },
                    { 109, "findDotProductToTwoPoints.json", null, null, "/findDotProductToTwoPoints/", 3, null, 22, "POST", null, null, null, null, "findDotProductToTwoPoints.html", null, null, "Find Dot Product To Two Points" },
                    { 110, "findDifferenceTwoPoints.json", null, null, "/findDifferenceTwoPoints/", 3, null, 22, "POST", null, null, null, null, "findDifferenceTwoPoints.html", null, null, "Find Difference Two Points" },
                    { 111, "wherePointOnLine.json", null, null, "/wherePointOnLine/", 3, null, 22, "POST", null, null, null, null, "wherePointOnLine.html", null, null, "Where Point On Line" },
                    { 112, "findInsectionPointToTwoLines.json", null, null, "/findInsectionPointToTwoLines/", 3, null, 22, "POST", null, null, null, null, "findInsectionPointToTwoLines.html", null, null, "Find Insection Point To Two Lines" },
                    { 113, "findPointLength.json", null, null, "/findPointLength/", 3, null, 22, "POST", null, null, null, null, "findPointLength.html", null, null, "Find Point Length" },
                    { 114, "wherePointZone.json", null, null, "/wherePointZone/", 3, null, 22, "POST", null, null, null, null, "wherePointZone.html", null, null, "Where Point Zone" },
                    { 115, "findNearetPoint.json", null, null, "/findNearetPoint/", 3, null, 22, "POST", null, null, null, null, "findNearetPoint.html", null, null, "Find Nearest Point" },
                    { 116, "findStartAndStopAngle.json", null, null, "/findStartAndStopAngle/", 3, null, 22, "POST", null, null, null, null, "findStartAndStopAngle.html", null, null, "Find Start And Stop Angle" },
                    { 117, "findStartAndStopAngleTwoPoint.json", null, null, "/findStartAndStopAngleTwoPoint/", 3, null, 22, "POST", null, null, null, null, "findStartAndStopAngleTwoPoint.html", null, null, "Find Start And Stop Angle Two Point" },
                    { 118, "findPointOnCircle.json", null, null, "/findPointOnCircle/", 3, null, 22, "POST", null, null, null, null, "findPointOnCircle.html", null, null, "Find Point On Circle" },
                    { 119, "createuser.json", null, null, "/User/createuser", 4, null, 24, "POST", null, null, null, null, "createuser.html", null, null, "Create User" },
                    { 120, "getuser.json", null, null, "/User/getuser", 4, null, 24, "GET", null, null, null, null, "getuser.html", null, null, "Get User" },
                    { 121, "createtoken.json", null, null, "/Auth/createtoken", 4, null, 25, "POST", null, null, null, null, "createtoken.html", null, null, "Create Token" },
                    { 122, "createtokenbyclient.json", null, null, "/Auth/createtokenbyclient", 4, null, 25, "POST", null, null, null, null, "createtokenbyclient.html", null, null, "Create Token By Client" },
                    { 123, "createtokenbyrefreshtoken.json", null, null, "/Auth/createtokenbyrefreshtoken", 4, null, 25, "POST", null, null, null, null, "createtokenbyrefreshtoken.html", null, null, "Create Token By Refresh Token" },
                    { 124, "revokerefreshtoken.json", null, null, "/Auth/revokerefreshtoken", 4, null, 25, "POST", null, null, null, null, "revokerefreshtoken.html", null, null, "Revoke Refresh Token" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "MainTitles",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "MainTitles",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "MainTitles",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "MainTitles",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "MainTitles",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "MainTitles",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "95312bcd-0256-48c4-a6c7-56f2295e4b09", "72861f5f-47b5-4796-9097-99fcf1514e21", "user", "USER" },
                    { "954bb0de-c0ba-45ff-91e1-ffbb673a7abd", "1bba09f8-f793-45ce-b36d-cd8e118c417b", "manager", "MANAGER" },
                    { "ad5f5093-f21b-4462-b2d3-74aba3affac5", "d3d39669-b9ce-4aeb-a452-02e448a68307", "admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 35,
                column: "Title",
                value: "Elements By Draw Wih Attributes");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 87,
                column: "Body",
                value: "pointtypedelete");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 88,
                column: "Body",
                value: "pointtypeupdate");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 91,
                column: "Body",
                value: "radiusesdelete");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 92,
                column: "Body",
                value: "radiusesupdate");
        }
    }
}
