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
                keyValue: "a6ce1cd0-d663-4d0e-8241-9790272c5a82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1be118a-dcae-499c-aede-e586b0b4aac0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8962142-15f1-4ebb-b55e-f84e7b79b0cb");

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
                keyValue: 23,
                column: "Header",
                value: "/Draw/setIsFinish?finish=true");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 30,
                column: "Body",
                value: null);

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 31,
                column: "Body",
                value: null);

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "Id", "Body", "Explanation", "GifUrl", "Header", "IndexId", "LogoUrl", "MainTitleId", "ResponeseType", "Return", "ShortcutUrl1", "ShortcutUrl2", "ShortcutUrl3", "TextUrl1", "TextUrl2", "TextUrl3", "Title" },
                values: new object[,]
                {
                    { 32, null, null, null, "/Element/elements", 2, null, 12, "GET", null, null, null, null, "Elements.html", null, null, "Elements" },
                    { 33, null, null, null, "/Element/elementswithatt", 2, null, 12, "GET", null, null, null, null, "ElementsWithAtt.html", null, null, "Elements With Attributes" },
                    { 34, null, null, null, "/Element/elementsbydraw?drawId=0", 2, null, 12, "GET", null, null, null, null, "ElementsByDraw.html", null, null, "Elements By Draw" },
                    { 35, null, null, null, "/Element/elementsbydrawwithatt?drawId=0", 2, null, 12, "GET", null, null, null, null, "ElementsByDrawWithAtt.html", null, null, "Elements By Draw Wih Attributes" },
                    { 36, null, null, null, "/Element/elementsbylayer?layerId=0", 2, null, 12, "GET", null, null, null, null, "ElementsByLayer.html", null, null, "Elements By Layer" },
                    { 37, null, null, null, "/Element/elementsbylayerwithatt?layerId=0", 2, null, 12, "GET", null, null, null, null, "ElementsByLayerWithAtt.html", null, null, "Elements By Layer With Attributes" },
                    { 38, "ElementsAdd.json", null, null, "/Element/elements/add", 2, null, 12, "POST", null, null, null, null, "ElementsAdd.html", null, null, "Elements Add" },
                    { 39, "ElementsDelete.json", null, null, "/Element/elements/delete", 2, null, 12, "DELETE", null, null, null, null, "ElementsDelete.html", null, null, "Elements Delete" },
                    { 40, "ElementsUpdate.json", null, null, "/Element/elements/update", 2, null, 12, "PUT", null, null, null, null, "ElementsUpdate.html", null, null, "Elements Update" },
                    { 41, null, null, null, "/Element/elements/{id}", 2, null, 12, "GET", null, null, null, null, "ElementId.html", null, null, "Element" },
                    { 42, null, null, null, "/Element/elements/{id}/elementType", 2, null, 12, "GET", null, null, null, null, "ElementIdElementType.html", null, null, "Element Element Type" },
                    { 43, null, null, null, "/Element/elements/{id}/pen", 2, null, 12, "GET", null, null, null, null, "ElementIdPen.html", null, null, "Element Pen" },
                    { 44, null, null, null, "/Element/elements/{id}/layer", 2, null, 12, "GET", null, null, null, null, "ElementIdLayer.html", null, null, "Element Layer" },
                    { 45, null, null, null, "/Element/elements/{id}/radiuses", 2, null, 12, "GET", null, null, null, null, "ElementIdRadiuses.html", null, null, "Element Radiuses" },
                    { 46, null, null, null, "/Element/elements/{id}/ssangles", 2, null, 12, "GET", null, null, null, null, "ElementIdSSAngles.html", null, null, "Element SSAngles" },
                    { 47, null, null, null, "/Element/elements/{id}/points", 2, null, 12, "GET", null, null, null, null, "ElementIdPoints.html", null, null, "Element Points" },
                    { 48, null, null, null, "/ElementType/elementTypes", 2, null, 13, "GET", null, null, null, null, "ElementTypes.html", null, null, "Element Types" },
                    { 49, null, null, null, "/ElementType/elementTypes/{id}", 2, null, 13, "GET", null, null, null, null, "ElementType.html", null, null, "Element Type" },
                    { 50, "ElementTypeAdd.json", null, null, "/ElementType/elementTypes/add", 2, null, 13, "POST", null, null, null, null, "ElementTypeAdd.html", null, null, "Element Types Add" },
                    { 51, "ElementTypeDelete.json", null, null, "/ElementType/elementTypes/delete", 2, null, 13, "DELETE", null, null, null, null, "ElementTypeDelete.html", null, null, "Element Types Delete" },
                    { 52, "ElementTypeUpdate.json", null, null, "/ElementType/elementTypes/update", 2, null, 13, "PUT", null, null, null, null, "ElementTypeUpdate.html", null, null, "Element Types Update" },
                    { 53, null, null, null, "/Layer/layers", 2, null, 14, "GET", null, null, null, null, "Layers.html", null, null, "Layers" },
                    { 54, null, null, null, "/Layer/layers?drawId=0", 2, null, 14, "POST", null, null, null, null, "LayersDrawId.html", null, null, "Draw Layers" },
                    { 55, null, null, null, "/Layer/layerswithpen?drawId=0", 2, null, 14, "POST", null, null, null, null, "LayersDrawIdWithPen.html", null, null, "Draw Layers With Pen" },
                    { 56, "LayersAdd.json", null, null, "/Layer/layers/add", 2, null, 14, "POST", null, null, null, null, "LayersAdd.html", null, null, "Layers Add" },
                    { 57, "LayersDelete.json", null, null, "/Layer/layers/delete", 2, null, 14, "DELETE", null, null, null, null, "LayersDelete.html", null, null, "Layers Delete" },
                    { 58, "LayersUpdate.json", null, null, "/Layer/layers/update", 2, null, 14, "PUT", null, null, null, null, "LayersUpdate.html", null, null, "Layers Update" },
                    { 59, null, null, null, "/Layer/layers/{id}", 2, null, 14, "GET", null, null, null, null, "Layer.html", null, null, "Layer" },
                    { 60, null, null, null, "/Layer/layers/{id}/elements", 2, null, 14, "GET", null, null, null, null, "Layerelements.html", null, null, "Layer Elements" },
                    { 61, null, null, null, "/Layer/layers/{id}/pen", 2, null, 14, "GET", null, null, null, null, "Layerpen.html", null, null, "Layer Pen" },
                    { 62, null, null, null, "/Pen/pens", 2, null, 15, "GET", null, null, null, null, "Pens.html", null, null, "Pens" },
                    { 63, null, null, null, "/Pen/penswithatt", 2, null, 15, "GET", null, null, null, null, "Penswithatt.html", null, null, "Pens With Attributes" },
                    { 64, null, null, null, "/Pen/pens/{id}", 2, null, 15, "GET", null, null, null, null, "Pen.html", null, null, "Pen" },
                    { 65, null, null, null, "/Pen/pens/{id}/penstyle", 2, null, 15, "GET", null, null, null, null, "Penpenstyle.html", null, null, "Pen PenStyle" },
                    { 66, "Pensadd.json", null, null, "/Pen/pens/add", 2, null, 15, "POST", null, null, null, null, "Penadd.html", null, null, "Pen Add" },
                    { 67, "Pensdelete.json", null, null, "/Pen/pens/delete", 2, null, 15, "DELETE", null, null, null, null, "Pendelete.html", null, null, "Pen Delete" },
                    { 68, "Pensupdate.json", null, null, "/Pen/pens/update", 2, null, 15, "PUT", null, null, null, null, "Penupdate.html", null, null, "Pen Update" },
                    { 69, null, null, null, "/PenStyles/penstyles", 2, null, 16, "GET", null, null, null, null, "Penstyles.html", null, null, "PenStyles" },
                    { 70, null, null, null, "/PenStyles/penstyles/{id}", 2, null, 16, "GET", null, null, null, null, "Penstyle.html", null, null, "PenStyle" },
                    { 71, "Penstyleadd.json", null, null, "/PenStyles/penstyles/add", 2, null, 16, "POST", null, null, null, null, "Penstylesadd.html", null, null, "PenStyles Add" },
                    { 72, "Penstyledelete.json", null, null, "/PenStyles/penstyles/delete", 2, null, 16, "DELETE", null, null, null, null, "Penstylesdelete.html", null, null, "PenStyles Delete" },
                    { 73, "Penstyleupdate.json", null, null, "/PenStyles/penstyles/update", 2, null, 16, "PUT", null, null, null, null, "Penstylesupdate.html", null, null, "PenStyles Update" },
                    { 74, null, null, null, "/Point/points", 2, null, 17, "GET", null, null, null, null, "Points.html", null, null, "Points" },
                    { 75, null, null, null, "/Point/pointsbyelement?elementId=0", 2, null, 17, "GET", null, null, null, null, "Pointsbyelement.html", null, null, "Points By Element" },
                    { 76, null, null, null, "/Point/pointsbylayer?layerId=0", 2, null, 17, "GET", null, null, null, null, "Pointsbylayer.html", null, null, "Points By Layer" },
                    { 77, null, null, null, "/Point/pointsbydraw?drawId=0", 2, null, 17, "GET", null, null, null, null, "Pointsbydraw.html", null, null, "Points By Draw" },
                    { 78, "Pointsadd.json", null, null, "/Point/points/add", 2, null, 17, "GET", null, null, null, null, "Pointsadd.html", null, null, "Points Add" },
                    { 79, "Pointsdelete.json", null, null, "/Point/points/delete", 2, null, 17, "DELETE", null, null, null, null, "Pointsdelete.html", null, null, "Points Delete" },
                    { 80, "Pointsupdate.json", null, null, "/Point/points/update", 2, null, 17, "PUT", null, null, null, null, "Pointsupdate.html", null, null, "Points Update" },
                    { 81, null, null, null, "/Point/points/{id}", 2, null, 17, "GET", null, null, null, null, "Point.html", null, null, "Point" },
                    { 82, null, null, null, "/Point/points/{id}/element", 2, null, 17, "GET", null, null, null, null, "Pointelement.html", null, null, "Point Element" },
                    { 83, null, null, null, "/Point/points/{id}/pointtype", 2, null, 17, "GET", null, null, null, null, "Pointpointtype.html", null, null, "Point PointType" },
                    { 84, null, null, null, "/PointType/pointtypes", 2, null, 18, "GET", null, null, null, null, "PointTypes.html", null, null, "PointTypes" },
                    { 85, null, null, null, "/PointType/pointtypes/{id}", 2, null, 18, "GET", null, null, null, null, "PointType.html", null, null, "PointType" },
                    { 86, "pointtypeadd", null, null, "/PointType/pointtypes/add", 2, null, 18, "POST", null, null, null, null, "PointTypeadd.html", null, null, "PointType Add" },
                    { 87, "pointtypedelete", null, null, "/PointType/pointtypes/delete", 2, null, 18, "DELETE", null, null, null, null, "PointTypedelete.html", null, null, "PointType Delete" },
                    { 88, "pointtypeupdate", null, null, "/PointType/pointtypes/update", 2, null, 18, "PUT", null, null, null, null, "PointTypeupdate.html", null, null, "PointType Update" },
                    { 89, null, null, null, "/Radius/radiuses", 2, null, 19, "GET", null, null, null, null, "Radiuses.html", null, null, "Radiuses" },
                    { 90, "radiusesadd", null, null, "/Radius/radiuses/add", 2, null, 19, "POST", null, null, null, null, "Radiusesadd.html", null, null, "Radiuses Add" },
                    { 91, "radiusesdelete", null, null, "/Radius/radiuses/delete", 2, null, 19, "DELETE", null, null, null, null, "Radiusesdelete.html", null, null, "Radiuses Delete" },
                    { 92, "radiusesupdate", null, null, "/Radius/radiuses/update", 2, null, 19, "PUT", null, null, null, null, "Radiusesupdate.html", null, null, "Radiuses Update" },
                    { 93, null, null, null, "/Radius/radiuses/{id}", 2, null, 19, "GET", null, null, null, null, "Radiuse.html", null, null, "Radiuse" },
                    { 94, null, null, null, "/SSAngle/ssangles/{id}", 2, null, 20, "GET", null, null, null, null, "SSAngle.html", null, null, "SSAngle" },
                    { 95, null, null, null, "/SSAngle/ssangles", 2, null, 20, "GET", null, null, null, null, "SSAngles.html", null, null, "SSAngles" },
                    { 96, "SSAnglesadd.json", null, null, "/SSAngle/ssangles/add", 2, null, 20, "POST", null, null, null, null, "SSAnglesadd.html", null, null, "SSAngles Add" },
                    { 97, "SSAnglesdelete.json", null, null, "/SSAngle/ssangles/delete", 2, null, 20, "DELETE", null, null, null, null, "SSAnglesdelete.html", null, null, "SSAngles Delete" },
                    { 98, "SSAnglesupdate.json", null, null, "/SSAngle/ssangles/update", 2, null, 20, "PUT", null, null, null, null, "SSAnglesupdate.html", null, null, "SSAngles Update" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a6ce1cd0-d663-4d0e-8241-9790272c5a82", "5232b3a8-183a-43b3-a4ba-a27fcd6d66da", "admin", "ADMIN" },
                    { "b1be118a-dcae-499c-aede-e586b0b4aac0", "b63a8cbd-a446-4b1e-ba15-94bf6313d483", "user", "USER" },
                    { "e8962142-15f1-4ebb-b55e-f84e7b79b0cb", "0a7e26e8-fa44-451f-b38b-809c4fb17ea7", "manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 23,
                column: "Header",
                value: "/Draw/setIsFinish");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 30,
                column: "Body",
                value: "DrawBoxId.json");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 31,
                column: "Body",
                value: "DrawBoxIdLayers.json");
        }
    }
}
