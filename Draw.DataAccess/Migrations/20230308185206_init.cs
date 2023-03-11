using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Draw.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ColorName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ColorRed = table.Column<int>(type: "int", nullable: false),
                    ColorBlue = table.Column<int>(type: "int", nullable: false),
                    ColorGreen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ColorId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ElementTypes",
                columns: table => new
                {
                    ElementTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ElementTypeName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementTypes", x => x.ElementTypeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PenStyles",
                columns: table => new
                {
                    PenStyleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PenStyleName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PenStyles", x => x.PenStyleId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PointTypes",
                columns: table => new
                {
                    PointTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PointTypeName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointTypes", x => x.PointTypeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRefreshTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expiration = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshTokens", x => x.UserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Draws",
                columns: table => new
                {
                    DrawBoxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DrawName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draws", x => x.DrawBoxId);
                    table.ForeignKey(
                        name: "FK_Draws_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pens",
                columns: table => new
                {
                    PenId = table.Column<int>(type: "int", nullable: false),
                    PenName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PenColorId = table.Column<int>(type: "int", nullable: false),
                    PenStyleId = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Commands",
                columns: table => new
                {
                    DrawCommandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DrawCommandName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DrawCommandDrawBoxId = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Layers",
                columns: table => new
                {
                    LayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LayerName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LayerLock = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LayerVisibility = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LayerThickness = table.Column<float>(type: "float", nullable: false),
                    DrawBoxId = table.Column<int>(type: "int", nullable: false),
                    PenId = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    ElementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PenId = table.Column<int>(type: "int", nullable: false),
                    ElementTypeId = table.Column<int>(type: "int", nullable: false),
                    LayerId = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    PointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PointX = table.Column<double>(type: "double", nullable: false),
                    PointY = table.Column<double>(type: "double", nullable: false),
                    ElementId = table.Column<int>(type: "int", nullable: false),
                    PointTypeId = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Radiuses",
                columns: table => new
                {
                    RadiusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RadiusValue = table.Column<double>(type: "double", nullable: false),
                    RadiusElementId = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SSAngles",
                columns: table => new
                {
                    SSAngleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SSAngleType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SSAngleValue = table.Column<double>(type: "double", nullable: false),
                    SSAngleElementId = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15936a03-f075-429c-9e6c-107710ea500e", "e671a9ba-15d0-4937-bf04-ff5c4b7fc131", "user", "USER" },
                    { "4bf83e9d-0954-4de5-a2f0-4c72d1960d1b", "8de2157f-635c-493d-8468-be40ef6795e0", "manager", "MANAGER" },
                    { "6881c656-d38d-42ba-be2c-f51b65fe8fec", "c4aa477b-50b6-40ac-bcfa-06c0b34b70b8", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b21972e1-742f-4fa7-be46-1189d9cab7ca", 1, "5f224274-319f-403e-b440-036848f36ffc", null, false, false, null, null, null, null, "513", true, "af2c18e0-17c3-4de8-828c-eeff4f0e2e7a", false, "zahid" },
                    { "b21972e1-742f-4fa7-be46-1189d9cab7cb", 1, "164c56a8-64d1-43c0-b196-62190d931839", null, false, false, null, null, null, null, "513", true, "63919bf6-6ee9-4016-84b3-c8bf9ee1a497", false, "ali" },
                    { "b21972e1-742f-4fa7-be46-1189d9cab7cc", 1, "dac9f1cd-0445-46ca-aba6-4f39ec1f65b6", null, false, false, null, null, null, null, "513", true, "af1e497a-953e-4ebf-80e8-afe23437c152", false, "zeynep" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorId", "ColorBlue", "ColorGreen", "ColorName", "ColorRed" },
                values: new object[,]
                {
                    { 1, 255, 255, "white", 255 },
                    { 2, 0, 0, "red", 211 },
                    { 3, 127, 0, "orange", 255 },
                    { 4, 184, 255, "blue", 99 },
                    { 5, 0, 0, "black", 0 },
                    { 6, 153, 153, "gray", 153 },
                    { 7, 128, 77, "green", 74 }
                });

            migrationBuilder.InsertData(
                table: "ElementTypes",
                columns: new[] { "ElementTypeId", "ElementTypeName" },
                values: new object[,]
                {
                    { 1, "line" },
                    { 2, "circle" },
                    { 3, "rectangle" },
                    { 4, "arc" },
                    { 5, "ellips" },
                    { 6, "spline" }
                });

            migrationBuilder.InsertData(
                table: "PenStyles",
                columns: new[] { "PenStyleId", "PenStyleName" },
                values: new object[,]
                {
                    { 1, "solid" },
                    { 2, "dot" }
                });

            migrationBuilder.InsertData(
                table: "PointTypes",
                columns: new[] { "PointTypeId", "PointTypeName" },
                values: new object[,]
                {
                    { 1, "end" },
                    { 2, "center" },
                    { 3, "middle" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "DrawBoxId", "DrawName", "UserId" },
                values: new object[,]
                {
                    { 1, "c1", "b21972e1-742f-4fa7-be46-1189d9cab7ca" },
                    { 2, "c2", "b21972e1-742f-4fa7-be46-1189d9cab7ca" },
                    { 3, "c1", "b21972e1-742f-4fa7-be46-1189d9cab7cb" }
                });

            migrationBuilder.InsertData(
                table: "Pens",
                columns: new[] { "PenId", "PenColorId", "PenName", "PenStyleId" },
                values: new object[,]
                {
                    { 1, 1, "pen1", 1 },
                    { 2, 2, "pen2", 2 }
                });

            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "DrawCommandId", "DrawCommandDrawBoxId", "DrawCommandName" },
                values: new object[,]
                {
                    { 1, 1, "dc1" },
                    { 2, 1, "dc2" },
                    { 3, 1, "dc3" }
                });

            migrationBuilder.InsertData(
                table: "Layers",
                columns: new[] { "LayerId", "DrawBoxId", "LayerLock", "LayerName", "LayerThickness", "LayerVisibility", "PenId" },
                values: new object[,]
                {
                    { 1, 1, false, "0", 1f, false, 1 },
                    { 2, 1, false, "a", 1f, false, 2 },
                    { 3, 1, false, "b", 1f, false, 1 }
                });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "ElementId", "ElementTypeId", "LayerId", "PenId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 1, 1 },
                    { 3, 1, 1, 1 },
                    { 4, 5, 1, 1 },
                    { 5, 4, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "PointId", "ElementId", "PointTypeId", "PointX", "PointY" },
                values: new object[,]
                {
                    { 1, 1, 1, 10.0, 8.0 },
                    { 2, 1, 1, 15.0, 20.0 },
                    { 3, 2, 1, 5.0, 10.0 },
                    { 4, 2, 1, 9.0, 20.0 },
                    { 5, 3, 1, 7.0, 3.0 },
                    { 6, 3, 1, 2.0, 1.0 },
                    { 7, 4, 2, 0.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Radiuses",
                columns: new[] { "RadiusId", "RadiusElementId", "RadiusValue" },
                values: new object[,]
                {
                    { 1, 4, 10.0 },
                    { 2, 4, 15.0 }
                });

            migrationBuilder.InsertData(
                table: "SSAngles",
                columns: new[] { "SSAngleId", "SSAngleElementId", "SSAngleType", "SSAngleValue" },
                values: new object[,]
                {
                    { 1, 1, "start", 0.0 },
                    { 2, 1, "stop", 30.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Commands");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "Radiuses");

            migrationBuilder.DropTable(
                name: "SSAngles");

            migrationBuilder.DropTable(
                name: "UserRefreshTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

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
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "PenStyles");
        }
    }
}
