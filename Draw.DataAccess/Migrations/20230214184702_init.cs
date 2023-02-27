﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Draw.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ColorName = table.Column<string>(type: "TEXT", nullable: false),
                    ColorRed = table.Column<int>(type: "INTEGER", nullable: false),
                    ColorBlue = table.Column<int>(type: "INTEGER", nullable: false),
                    ColorGreen = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ColorId);
                });

            migrationBuilder.CreateTable(
                name: "ElementTypes",
                columns: table => new
                {
                    ElementTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ElementTypeName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementTypes", x => x.ElementTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PenStyles",
                columns: table => new
                {
                    PenStyleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PenStyleName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PenStyles", x => x.PenStyleId);
                });

            migrationBuilder.CreateTable(
                name: "PointTypes",
                columns: table => new
                {
                    PointTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PointTypeName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointTypes", x => x.PointTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    UserPassword = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Pens",
                columns: table => new
                {
                    PenId = table.Column<int>(type: "INTEGER", nullable: false),
                    PenName = table.Column<string>(type: "TEXT", nullable: false),
                    PenColorId = table.Column<int>(type: "INTEGER", nullable: false),
                    PenStyleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pens", x => x.PenId);
                    table.ForeignKey(
                        name: "FK_Pens_Colors_PenId",
                        column: x => x.PenId,
                        principalTable: "Colors",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pens_PenStyles_PenId",
                        column: x => x.PenId,
                        principalTable: "PenStyles",
                        principalColumn: "PenStyleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Draws",
                columns: table => new
                {
                    DrawBoxId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DrawName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draws", x => x.DrawBoxId);
                    table.ForeignKey(
                        name: "FK_Draws_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commands",
                columns: table => new
                {
                    DrawCommandId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DrawCommandName = table.Column<string>(type: "TEXT", nullable: false),
                    DrawCommandDrawBoxId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.DrawCommandId);
                    table.ForeignKey(
                        name: "FK_Commands_Draws_DrawCommandDrawBoxId",
                        column: x => x.DrawCommandDrawBoxId,
                        principalTable: "Draws",
                        principalColumn: "DrawBoxId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Layers",
                columns: table => new
                {
                    LayerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LayerName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    LayerLock = table.Column<bool>(type: "INTEGER", nullable: false),
                    LayerVisibility = table.Column<bool>(type: "INTEGER", nullable: false),
                    LayerThickness = table.Column<float>(type: "REAL", nullable: false),
                    DrawBoxId = table.Column<int>(type: "INTEGER", nullable: false),
                    PenId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layers", x => x.LayerId);
                    table.ForeignKey(
                        name: "FK_Layers_Draws_DrawBoxId",
                        column: x => x.DrawBoxId,
                        principalTable: "Draws",
                        principalColumn: "DrawBoxId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Layers_Pens_PenId",
                        column: x => x.PenId,
                        principalTable: "Pens",
                        principalColumn: "PenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PenId = table.Column<int>(type: "INTEGER", nullable: false),
                    ElementTypeId = table.Column<int>(type: "INTEGER", maxLength: 200, nullable: false),
                    LayerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.ElementId);
                    table.ForeignKey(
                        name: "FK_Elements_ElementTypes_ElementTypeId",
                        column: x => x.ElementTypeId,
                        principalTable: "ElementTypes",
                        principalColumn: "ElementTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Elements_Layers_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layers",
                        principalColumn: "LayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Elements_Pens_PenId",
                        column: x => x.PenId,
                        principalTable: "Pens",
                        principalColumn: "PenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    PointId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PointX = table.Column<double>(type: "REAL", nullable: false),
                    PointY = table.Column<double>(type: "REAL", nullable: false),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false),
                    PointTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.PointId);
                    table.ForeignKey(
                        name: "FK_Points_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Points_PointTypes_PointTypeId",
                        column: x => x.PointTypeId,
                        principalTable: "PointTypes",
                        principalColumn: "PointTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Radiuses",
                columns: table => new
                {
                    RadiusId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RadiusValue = table.Column<double>(type: "REAL", nullable: false),
                    RadiusElementId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radiuses", x => x.RadiusId);
                    table.ForeignKey(
                        name: "FK_Radiuses_Elements_RadiusElementId",
                        column: x => x.RadiusElementId,
                        principalTable: "Elements",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SSAngles",
                columns: table => new
                {
                    SSAngleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SSAngleType = table.Column<string>(type: "TEXT", nullable: false),
                    SSAngleValue = table.Column<double>(type: "REAL", nullable: false),
                    SSAngleElementId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSAngles", x => x.SSAngleId);
                    table.ForeignKey(
                        name: "FK_SSAngles_Elements_SSAngleElementId",
                        column: x => x.SSAngleElementId,
                        principalTable: "Elements",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorId", "ColorBlue", "ColorGreen", "ColorName", "ColorRed" },
                values: new object[] { 1, 255, 255, "white", 255 });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorId", "ColorBlue", "ColorGreen", "ColorName", "ColorRed" },
                values: new object[] { 2, 0, 0, "red", 211 });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorId", "ColorBlue", "ColorGreen", "ColorName", "ColorRed" },
                values: new object[] { 3, 127, 0, "orange", 255 });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorId", "ColorBlue", "ColorGreen", "ColorName", "ColorRed" },
                values: new object[] { 4, 184, 255, "blue", 99 });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorId", "ColorBlue", "ColorGreen", "ColorName", "ColorRed" },
                values: new object[] { 5, 0, 0, "black", 0 });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorId", "ColorBlue", "ColorGreen", "ColorName", "ColorRed" },
                values: new object[] { 6, 153, 153, "gray", 153 });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorId", "ColorBlue", "ColorGreen", "ColorName", "ColorRed" },
                values: new object[] { 7, 128, 77, "green", 74 });

            migrationBuilder.InsertData(
                table: "ElementTypes",
                columns: new[] { "ElementTypeId", "ElementTypeName" },
                values: new object[] { 1, "line" });

            migrationBuilder.InsertData(
                table: "ElementTypes",
                columns: new[] { "ElementTypeId", "ElementTypeName" },
                values: new object[] { 2, "circle" });

            migrationBuilder.InsertData(
                table: "ElementTypes",
                columns: new[] { "ElementTypeId", "ElementTypeName" },
                values: new object[] { 3, "rectangle" });

            migrationBuilder.InsertData(
                table: "ElementTypes",
                columns: new[] { "ElementTypeId", "ElementTypeName" },
                values: new object[] { 4, "arc" });

            migrationBuilder.InsertData(
                table: "ElementTypes",
                columns: new[] { "ElementTypeId", "ElementTypeName" },
                values: new object[] { 5, "ellips" });

            migrationBuilder.InsertData(
                table: "ElementTypes",
                columns: new[] { "ElementTypeId", "ElementTypeName" },
                values: new object[] { 6, "spline" });

            migrationBuilder.InsertData(
                table: "PenStyles",
                columns: new[] { "PenStyleId", "PenStyleName" },
                values: new object[] { 1, "solid" });

            migrationBuilder.InsertData(
                table: "PenStyles",
                columns: new[] { "PenStyleId", "PenStyleName" },
                values: new object[] { 2, "dot" });

            migrationBuilder.InsertData(
                table: "PointTypes",
                columns: new[] { "PointTypeId", "PointTypeName" },
                values: new object[] { 1, "end" });

            migrationBuilder.InsertData(
                table: "PointTypes",
                columns: new[] { "PointTypeId", "PointTypeName" },
                values: new object[] { 2, "center" });

            migrationBuilder.InsertData(
                table: "PointTypes",
                columns: new[] { "PointTypeId", "PointTypeName" },
                values: new object[] { 3, "middle" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "UserName", "UserPassword" },
                values: new object[] { 1, "zahid", "123456" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "UserName", "UserPassword" },
                values: new object[] { 2, "ali", "123456" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "UserName", "UserPassword" },
                values: new object[] { 3, "zeynep", "123456" });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "DrawBoxId", "DrawName", "UserId" },
                values: new object[] { 1, "c1", 1 });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "DrawBoxId", "DrawName", "UserId" },
                values: new object[] { 2, "c2", 1 });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "DrawBoxId", "DrawName", "UserId" },
                values: new object[] { 3, "c1", 2 });

            migrationBuilder.InsertData(
                table: "Pens",
                columns: new[] { "PenId", "PenColorId", "PenName", "PenStyleId" },
                values: new object[] { 1, 1, "pen1", 1 });

            migrationBuilder.InsertData(
                table: "Pens",
                columns: new[] { "PenId", "PenColorId", "PenName", "PenStyleId" },
                values: new object[] { 2, 2, "pen2", 2 });

            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "DrawCommandId", "DrawCommandDrawBoxId", "DrawCommandName" },
                values: new object[] { 1, 1, "dc1" });

            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "DrawCommandId", "DrawCommandDrawBoxId", "DrawCommandName" },
                values: new object[] { 2, 1, "dc2" });

            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "DrawCommandId", "DrawCommandDrawBoxId", "DrawCommandName" },
                values: new object[] { 3, 1, "dc3" });

            migrationBuilder.InsertData(
                table: "Layers",
                columns: new[] { "LayerId", "DrawBoxId", "LayerLock", "LayerName", "LayerThickness", "LayerVisibility", "PenId" },
                values: new object[] { 1, 1, false, "0", 1f, false, 1 });

            migrationBuilder.InsertData(
                table: "Layers",
                columns: new[] { "LayerId", "DrawBoxId", "LayerLock", "LayerName", "LayerThickness", "LayerVisibility", "PenId" },
                values: new object[] { 2, 1, false, "a", 1f, false, 2 });

            migrationBuilder.InsertData(
                table: "Layers",
                columns: new[] { "LayerId", "DrawBoxId", "LayerLock", "LayerName", "LayerThickness", "LayerVisibility", "PenId" },
                values: new object[] { 3, 1, false, "b", 1f, false, 1 });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "ElementId", "ElementTypeId", "LayerId", "PenId" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "ElementId", "ElementTypeId", "LayerId", "PenId" },
                values: new object[] { 2, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "ElementId", "ElementTypeId", "LayerId", "PenId" },
                values: new object[] { 3, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "ElementId", "ElementTypeId", "LayerId", "PenId" },
                values: new object[] { 4, 5, 1, 1 });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "ElementId", "ElementTypeId", "LayerId", "PenId" },
                values: new object[] { 5, 4, 1, 1 });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "PointId", "ElementId", "PointTypeId", "PointX", "PointY" },
                values: new object[] { 1, 1, 1, 10.0, 8.0 });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "PointId", "ElementId", "PointTypeId", "PointX", "PointY" },
                values: new object[] { 2, 1, 1, 15.0, 20.0 });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "PointId", "ElementId", "PointTypeId", "PointX", "PointY" },
                values: new object[] { 3, 2, 1, 5.0, 10.0 });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "PointId", "ElementId", "PointTypeId", "PointX", "PointY" },
                values: new object[] { 4, 2, 1, 9.0, 20.0 });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "PointId", "ElementId", "PointTypeId", "PointX", "PointY" },
                values: new object[] { 5, 3, 1, 7.0, 3.0 });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "PointId", "ElementId", "PointTypeId", "PointX", "PointY" },
                values: new object[] { 6, 3, 1, 2.0, 1.0 });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "PointId", "ElementId", "PointTypeId", "PointX", "PointY" },
                values: new object[] { 7, 4, 2, 0.0, 0.0 });

            migrationBuilder.InsertData(
                table: "Radiuses",
                columns: new[] { "RadiusId", "RadiusElementId", "RadiusValue" },
                values: new object[] { 1, 4, 10.0 });

            migrationBuilder.InsertData(
                table: "Radiuses",
                columns: new[] { "RadiusId", "RadiusElementId", "RadiusValue" },
                values: new object[] { 2, 4, 15.0 });

            migrationBuilder.InsertData(
                table: "SSAngles",
                columns: new[] { "SSAngleId", "SSAngleElementId", "SSAngleType", "SSAngleValue" },
                values: new object[] { 1, 1, "start", 0.0 });

            migrationBuilder.InsertData(
                table: "SSAngles",
                columns: new[] { "SSAngleId", "SSAngleElementId", "SSAngleType", "SSAngleValue" },
                values: new object[] { 2, 1, "stop", 30.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Commands_DrawCommandDrawBoxId",
                table: "Commands",
                column: "DrawCommandDrawBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Draws_UserId",
                table: "Draws",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_ElementTypeId",
                table: "Elements",
                column: "ElementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_LayerId",
                table: "Elements",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_PenId",
                table: "Elements",
                column: "PenId");

            migrationBuilder.CreateIndex(
                name: "IX_Layers_DrawBoxId",
                table: "Layers",
                column: "DrawBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Layers_LayerName",
                table: "Layers",
                column: "LayerName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Layers_PenId",
                table: "Layers",
                column: "PenId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_ElementId",
                table: "Points",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_PointTypeId",
                table: "Points",
                column: "PointTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Radiuses_RadiusElementId",
                table: "Radiuses",
                column: "RadiusElementId");

            migrationBuilder.CreateIndex(
                name: "IX_SSAngles_SSAngleElementId",
                table: "SSAngles",
                column: "SSAngleElementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commands");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "Radiuses");

            migrationBuilder.DropTable(
                name: "SSAngles");

            migrationBuilder.DropTable(
                name: "PointTypes");

            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "ElementTypes");

            migrationBuilder.DropTable(
                name: "Layers");

            migrationBuilder.DropTable(
                name: "Draws");

            migrationBuilder.DropTable(
                name: "Pens");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "PenStyles");
        }
    }
}