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
                name: "ElementTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MainTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IndexId = table.Column<int>(type: "int", nullable: false),
                    Explanation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TextUrl1 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TextUrl2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TextUrl3 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortcutUrl1 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortcutUrl2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortcutUrl3 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GifUrl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LogoUrl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ResponeseType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Header = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Return = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Body = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainTitles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PenStyles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PenStyles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PointTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointTypes", x => x.Id);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EditTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draws", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Draws_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IndexId = table.Column<int>(type: "int", nullable: false),
                    Explanation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TextUrl1 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TextUrl2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TextUrl3 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortcutUrl1 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortcutUrl2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortcutUrl3 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GifUrl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LogoUrl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ResponeseType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Header = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Return = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Body = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainTitleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Titles_MainTitles_MainTitleId",
                        column: x => x.MainTitleId,
                        principalTable: "MainTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Red = table.Column<int>(type: "int", nullable: false),
                    Blue = table.Column<int>(type: "int", nullable: false),
                    Green = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PenStyleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pens_PenStyles_PenStyleId",
                        column: x => x.PenStyleId,
                        principalTable: "PenStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DrawCommand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DrawBoxId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawCommand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrawCommand_Draws_DrawBoxId",
                        column: x => x.DrawBoxId,
                        principalTable: "Draws",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SubTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IndexId = table.Column<int>(type: "int", nullable: false),
                    Explanation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TextUrl1 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TextUrl2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TextUrl3 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortcutUrl1 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortcutUrl2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortcutUrl3 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GifUrl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LogoUrl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ResponeseType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Header = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Return = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Body = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BaseTitleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTitles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubTitles_Titles_BaseTitleId",
                        column: x => x.BaseTitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Layers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lock = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Visibility = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Thickness = table.Column<float>(type: "float", precision: 3, scale: 1, nullable: false),
                    DrawBoxId = table.Column<int>(type: "int", nullable: false),
                    PenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Layers_Draws_DrawBoxId",
                        column: x => x.DrawBoxId,
                        principalTable: "Draws",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Layers_Pens_PenId",
                        column: x => x.PenId,
                        principalTable: "Pens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PenId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    LayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elements_ElementTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ElementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Elements_Layers_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Elements_Pens_PenId",
                        column: x => x.PenId,
                        principalTable: "Pens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    X = table.Column<double>(type: "double", precision: 10, scale: 5, nullable: false),
                    Y = table.Column<double>(type: "double", precision: 10, scale: 5, nullable: false),
                    ElementId = table.Column<int>(type: "int", nullable: false),
                    PointTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Points_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Points_PointTypes_PointTypeId",
                        column: x => x.PointTypeId,
                        principalTable: "PointTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Radiuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<double>(type: "double", precision: 8, scale: 4, nullable: false),
                    ElementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radiuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Radiuses_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SSAngles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<double>(type: "double", precision: 8, scale: 4, nullable: false),
                    ElementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSAngles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SSAngles_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a6ce1cd0-d663-4d0e-8241-9790272c5a82", "5232b3a8-183a-43b3-a4ba-a27fcd6d66da", "admin", "ADMIN" },
                    { "b1be118a-dcae-499c-aede-e586b0b4aac0", "b63a8cbd-a446-4b1e-ba15-94bf6313d483", "user", "USER" },
                    { "e8962142-15f1-4ebb-b55e-f84e7b79b0cb", "0a7e26e8-fa44-451f-b38b-809c4fb17ea7", "manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "ElementTypes",
                columns: new[] { "Id", "Name" },
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
                table: "MainTitles",
                columns: new[] { "Id", "Body", "Explanation", "GifUrl", "Header", "IndexId", "LogoUrl", "ResponeseType", "Return", "ShortcutUrl1", "ShortcutUrl2", "ShortcutUrl3", "TextUrl1", "TextUrl2", "TextUrl3", "Title" },
                values: new object[,]
                {
                    { 1, null, null, null, null, 0, null, null, null, null, null, null, "DrawCAD.html", null, null, "DrawCAD" },
                    { 2, null, null, null, null, 0, null, null, null, null, null, null, "File.html", null, null, "File" },
                    { 3, null, null, null, null, 0, null, null, null, null, null, null, "Commands.html", null, null, "Commands" },
                    { 4, null, null, null, null, 0, "Layer.png", null, null, null, null, null, "Layer.html", null, null, "Layer" },
                    { 5, null, null, null, null, 0, null, null, null, null, null, null, "Snaps.html", null, null, "Snaps" },
                    { 6, null, null, null, null, 0, null, null, null, null, null, null, "Handles.html", null, null, "Handles" },
                    { 7, null, null, null, null, 0, "elementInfo.png", null, null, null, null, null, "Element Information.html", null, null, "Element Information" },
                    { 8, null, null, null, null, 0, null, null, null, null, null, null, "Other.html", null, null, "Other" },
                    { 9, null, null, null, null, 2, null, null, null, null, null, null, "DrawApi.html", null, null, "DrawApi" },
                    { 10, null, null, null, null, 2, null, null, null, null, null, null, "Draw.html", null, null, "Draw" },
                    { 11, null, null, null, null, 2, null, null, null, null, null, null, "DrawBox.html", null, null, "DrawBox" },
                    { 12, null, null, null, null, 2, null, null, null, null, null, null, "Element.html", null, null, "Element" },
                    { 13, null, null, null, null, 2, null, null, null, null, null, null, "ElementType.html", null, null, "ElementType" },
                    { 14, null, null, null, null, 2, null, null, null, null, null, null, "Layer.html", null, null, "Layer" },
                    { 15, null, null, null, null, 2, null, null, null, null, null, null, "Pen.html", null, null, "Pen" },
                    { 16, null, null, null, null, 2, null, null, null, null, null, null, "PenStyles.html", null, null, "PenStyles" },
                    { 17, null, null, null, null, 2, null, null, null, null, null, null, "Point.html", null, null, "Point" },
                    { 18, null, null, null, null, 2, null, null, null, null, null, null, "PointType.html", null, null, "PointType" },
                    { 19, null, null, null, null, 2, null, null, null, null, null, null, "Radius.html", null, null, "Radius" },
                    { 20, null, null, null, null, 2, null, null, null, null, null, null, "SSAngle.html", null, null, "SSAngle" }
                });

            migrationBuilder.InsertData(
                table: "PenStyles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "solid" },
                    { 2, "dot" }
                });

            migrationBuilder.InsertData(
                table: "PointTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "end" },
                    { 2, "center" },
                    { 3, "middle" }
                });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "Id", "Body", "Explanation", "GifUrl", "Header", "IndexId", "LogoUrl", "MainTitleId", "ResponeseType", "Return", "ShortcutUrl1", "ShortcutUrl2", "ShortcutUrl3", "TextUrl1", "TextUrl2", "TextUrl3", "Title" },
                values: new object[,]
                {
                    { 1, null, null, null, null, 0, null, 3, null, null, null, null, null, null, null, null, "Draw Commands" },
                    { 2, null, null, null, null, 0, null, 3, null, null, null, null, null, null, null, null, "Edit Commands" },
                    { 3, null, null, "endsnap.gif", null, 0, "closeendpoint.png", 5, null, null, "f6", null, null, "End Snap.html", null, null, "End Snap" },
                    { 4, null, null, "middlesnap.gif", null, 0, "CloseMidPoint.png", 5, null, null, "f7", null, null, "Middle Snap.html", null, null, "Middle Snap" },
                    { 5, null, null, "centersnap.gif", null, 0, "CloseCenter.png", 5, null, null, "f8", null, null, "Center Snap.html", null, null, "Center Snap" },
                    { 6, null, null, "nearestsnap.gif", null, 0, "CloseNearest.png", 5, null, null, "f9", null, null, "Nearest Snap.html", null, null, "Nearest Snap" },
                    { 7, null, null, "intersectionsnap.gif", null, 0, "CloseIntersection.png", 5, null, null, "f10", null, null, "Intersection Snap.html", null, null, "Intersection Snap" },
                    { 8, null, null, "polarmod.gif", null, 0, "ClosePain.png", 5, null, null, "f4", null, null, "Polar Mode.html", null, null, "Polar Mode" },
                    { 9, null, null, "orthomod.gif", null, 0, "CloseOrtho.png", 5, null, null, "f3", null, null, "Ortho Mode.html", null, null, "Ortho Mode" },
                    { 10, null, null, "gridsnap.gif", null, 0, "CloseGrid.png", 5, null, null, "f5", null, null, "Grid Snap.html", null, null, "Grid Snap" },
                    { 11, null, null, null, null, 0, "linewidthBtnClose.png", 8, null, null, null, null, null, "Line Width.html", null, null, "Line Width" },
                    { 12, null, null, "add.gif", null, 0, "addBtn.png", 2, null, null, null, null, null, "Add.html", null, null, "Add" },
                    { 13, null, null, "open.gif", null, 0, "openfile.png", 2, null, null, null, null, null, "Open.html", null, null, "Open" },
                    { 14, null, null, "push.gif", null, 0, "saveCloud.png", 2, null, null, null, null, null, "Push.html", null, null, "Push" },
                    { 15, null, null, "pull.gif", null, 0, "getCloud.png", 2, null, null, null, null, null, "Pull.html", null, null, "Pull" },
                    { 16, null, null, null, null, 0, null, 2, null, null, null, null, null, "Save.html", null, null, "Save" },
                    { 17, null, null, null, null, 0, null, 2, null, null, null, null, null, "Save Cloud.html", null, null, "Save Cloud" },
                    { 18, "StartCommand.json", null, null, "/Draw/startCommand", 2, null, 10, "POST", null, null, null, null, "StartCommand.html", null, null, "Start Command" },
                    { 19, "AddCoordinate.json", null, null, "/Draw/addCoordinate", 2, null, 10, "POST", null, null, null, null, "AddCoordinate.html", null, null, "Add Coordinate" },
                    { 20, null, null, null, "/Draw/stopCommand", 2, null, 10, "PUT", null, null, null, null, "StopCommand.html", null, null, "Stop Command" },
                    { 21, "SetRadius.json", null, null, "/Draw/setRadius", 2, null, 10, "PUT", null, null, null, null, "SetRadius.html", null, null, "Set Radius" },
                    { 22, "SetElementsId.json", null, null, "/Draw/setElementsId", 2, null, 10, "PUT", null, null, null, null, "SetElementsId.html", null, null, "Set Elements Id" },
                    { 23, null, null, null, "/Draw/setIsFinish", 2, null, 10, "PUT", null, null, null, null, "SetIsFinish.html", null, null, "Set Is Finish" },
                    { 24, "SaveDraw.json", null, null, "/Draw/saveDraw", 2, null, 10, "POST", null, null, null, null, "SaveDraw.html", null, null, "Save Draw" },
                    { 25, "ReadDraw.json", null, null, "/Draw/readDraw", 2, null, 10, "POST", null, null, null, null, "ReadDraw.html", null, null, "Read Draw" },
                    { 26, null, null, null, "/DrawBox/drawBoxes", 2, null, 11, "GET", null, null, null, null, "DrawBoxes.html", null, null, "Draw Boxes" },
                    { 27, "DrawBoxesAdd.json", null, null, "/DrawBox/drawBoxes/add", 2, null, 11, "GET", null, null, null, null, "DrawBoxesAdd.html", null, null, "Draw Boxes Add" },
                    { 28, "DrawBoxesDelete.json", null, null, "/DrawBox/drawBoxes/delete", 2, null, 11, "DELETE", null, null, null, null, "DrawBoxesDelete.html", null, null, "Draw Boxes Delete" },
                    { 29, "DrawBoxesUpdate.json", null, null, "/DrawBox/drawBoxes/update", 2, null, 11, "PUT", null, null, null, null, "DrawBoxesUpdate.html", null, null, "Draw Boxes Update" },
                    { 30, "DrawBoxId.json", null, null, "/DrawBox/drawBoxes/{id}", 2, null, 11, "GET", null, null, null, null, "DrawBoxId.html", null, null, "Draw Box" },
                    { 31, "DrawBoxIdLayers.json", null, null, "/DrawBox/drawBoxes/{id}/layers", 2, null, 11, "GET", null, null, null, null, "DrawBoxIdLayers.html", null, null, "Draw Box With Layers" }
                });

            migrationBuilder.InsertData(
                table: "SubTitles",
                columns: new[] { "Id", "BaseTitleId", "Body", "Explanation", "GifUrl", "Header", "IndexId", "LogoUrl", "ResponeseType", "Return", "ShortcutUrl1", "ShortcutUrl2", "ShortcutUrl3", "TextUrl1", "TextUrl2", "TextUrl3", "Title" },
                values: new object[,]
                {
                    { 1, 1, null, null, "line.gif", null, 0, "Line.png", null, null, "l", "enter", null, "Line.html", null, null, "Line" },
                    { 2, 1, null, null, "polyline.gif", null, 0, "polyline.png", null, null, "p", "o", "enter", "Polyline.html", null, null, "Polyline" },
                    { 3, 1, null, null, "rectangle.gif", null, 0, "Rectangle.png", null, null, "r", "enter", null, "Rectangle.html", null, null, "Rectangle" },
                    { 4, 1, null, null, "centerpointcircle.gif", null, 0, "CenterPointCircle.png", null, null, "c", "enter", null, "Circle Center Point.html", null, null, "Circle Center Point" },
                    { 5, 1, null, null, "treepointcircle.gif", null, 0, "treepointcircle.png", null, null, null, null, null, "Circle Tree Point.html", null, null, "Circle Tree Point" },
                    { 6, 1, null, null, "twopointcircle.gif", null, 0, "TwoPointCircle.png", null, null, null, null, null, "Circle Two Point.html", null, null, "Circle Two Point" },
                    { 7, 1, null, null, "centerradiuscircle.gif", null, 0, "Circle.png", null, null, null, null, null, "Circle Center Radius.html", null, null, "Circle Center Radius" },
                    { 8, 1, null, null, "treepointarc.gif", null, 0, "treepointarc.png", null, null, "a", "enter", null, "Arc Tree Point.html", null, null, "Arc Tree Point" },
                    { 9, 1, null, null, "twopointarc.gif", null, 0, "TwoPointCenterArc.png", null, null, null, null, null, "Arc Two Point.html", null, null, "Arc Two Point" },
                    { 10, 1, null, null, "ellipse.gif", null, 0, "Ellips.png", null, null, "e", "enter", null, "Ellipse.html", null, null, "Ellipse" },
                    { 11, 2, null, null, "move.gif", null, 0, "move.png", null, null, "m", "enter", null, "Move.html", null, null, "Move" },
                    { 12, 2, null, null, "copy.gif", null, 0, "Copy.png", null, null, "c", "o", "enter", "Copy.html", null, null, "Copy" },
                    { 13, 2, null, null, "rotate.gif", null, 0, "Rotate.png", null, null, "r", "o", "enter", "Rotate.html", null, null, "Rotate" },
                    { 14, 2, null, null, "scale.gif", null, 0, "Scale.png", null, null, "s", "enter", null, "Scale.html", null, null, "Scale" },
                    { 15, 2, null, null, "mirror.gif", null, 0, "Mirror.png", null, null, "m", "i", "enter", "Mirror.html", null, null, "Mirror" }
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
                name: "IX_DrawCommand_DrawBoxId",
                table: "DrawCommand",
                column: "DrawBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Draws_UserId",
                table: "Draws",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_LayerId",
                table: "Elements",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_PenId",
                table: "Elements",
                column: "PenId");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_TypeId",
                table: "Elements",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Layers_DrawBoxId",
                table: "Layers",
                column: "DrawBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Layers_PenId",
                table: "Layers",
                column: "PenId");

            migrationBuilder.CreateIndex(
                name: "IX_Pens_PenStyleId",
                table: "Pens",
                column: "PenStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Pens_UserId",
                table: "Pens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_ElementId",
                table: "Points",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_PointTypeId",
                table: "Points",
                column: "PointTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Radiuses_ElementId",
                table: "Radiuses",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_SSAngles_ElementId",
                table: "SSAngles",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTitles_BaseTitleId",
                table: "SubTitles",
                column: "BaseTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Titles_MainTitleId",
                table: "Titles",
                column: "MainTitleId");
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
                name: "DrawCommand");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "Radiuses");

            migrationBuilder.DropTable(
                name: "SSAngles");

            migrationBuilder.DropTable(
                name: "SubTitles");

            migrationBuilder.DropTable(
                name: "UserRefreshTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PointTypes");

            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "Titles");

            migrationBuilder.DropTable(
                name: "ElementTypes");

            migrationBuilder.DropTable(
                name: "Layers");

            migrationBuilder.DropTable(
                name: "MainTitles");

            migrationBuilder.DropTable(
                name: "Draws");

            migrationBuilder.DropTable(
                name: "Pens");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PenStyles");
        }
    }
}
