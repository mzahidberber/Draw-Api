﻿// <auto-generated />
using System;
using Draw.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Draw.DataAccess.Migrations
{
    [DbContext(typeof(DrawContext))]
    partial class DrawContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Draw.Entities.Concrete.DrawBox", b =>
                {
                    b.Property<int>("DrawBoxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DrawName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("DrawBoxId");

                    b.HasIndex("UserId");

                    b.ToTable("Draws");

                    b.HasData(
                        new
                        {
                            DrawBoxId = 1,
                            DrawName = "c1",
                            UserId = "b21972e1-742f-4fa7-be46-1189d9cab7ca"
                        },
                        new
                        {
                            DrawBoxId = 2,
                            DrawName = "c2",
                            UserId = "b21972e1-742f-4fa7-be46-1189d9cab7ca"
                        },
                        new
                        {
                            DrawBoxId = 3,
                            DrawName = "c1",
                            UserId = "b21972e1-742f-4fa7-be46-1189d9cab7cb"
                        });
                });

            modelBuilder.Entity("Draw.Entities.Concrete.DrawCommand", b =>
                {
                    b.Property<int>("DrawCommandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DrawCommandDrawBoxId")
                        .HasColumnType("int");

                    b.Property<string>("DrawCommandName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("DrawCommandId");

                    b.HasIndex("DrawCommandDrawBoxId");

                    b.ToTable("DrawCommand");
                });

            modelBuilder.Entity("Draw.Entities.Concrete.Element", b =>
                {
                    b.Property<int>("ElementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ElementTypeId")
                        .HasColumnType("int");

                    b.Property<int>("LayerId")
                        .HasColumnType("int");

                    b.Property<int>("PenId")
                        .HasColumnType("int");

                    b.HasKey("ElementId");

                    b.HasIndex("ElementTypeId");

                    b.HasIndex("LayerId");

                    b.HasIndex("PenId");

                    b.ToTable("Elements");

                    b.HasData(
                        new
                        {
                            ElementId = 1,
                            ElementTypeId = 1,
                            LayerId = 1,
                            PenId = 1
                        },
                        new
                        {
                            ElementId = 2,
                            ElementTypeId = 1,
                            LayerId = 1,
                            PenId = 1
                        },
                        new
                        {
                            ElementId = 3,
                            ElementTypeId = 1,
                            LayerId = 1,
                            PenId = 1
                        },
                        new
                        {
                            ElementId = 4,
                            ElementTypeId = 5,
                            LayerId = 1,
                            PenId = 1
                        },
                        new
                        {
                            ElementId = 5,
                            ElementTypeId = 4,
                            LayerId = 1,
                            PenId = 1
                        });
                });

            modelBuilder.Entity("Draw.Entities.Concrete.ElementType", b =>
                {
                    b.Property<int>("ElementTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ElementTypeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ElementTypeId");

                    b.ToTable("ElementTypes");

                    b.HasData(
                        new
                        {
                            ElementTypeId = 1,
                            ElementTypeName = "line"
                        },
                        new
                        {
                            ElementTypeId = 2,
                            ElementTypeName = "circle"
                        },
                        new
                        {
                            ElementTypeId = 3,
                            ElementTypeName = "rectangle"
                        },
                        new
                        {
                            ElementTypeId = 4,
                            ElementTypeName = "arc"
                        },
                        new
                        {
                            ElementTypeId = 5,
                            ElementTypeName = "ellips"
                        },
                        new
                        {
                            ElementTypeId = 6,
                            ElementTypeName = "spline"
                        });
                });

            modelBuilder.Entity("Draw.Entities.Concrete.Layer", b =>
                {
                    b.Property<int>("LayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DrawBoxId")
                        .HasColumnType("int");

                    b.Property<bool>("LayerLock")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LayerName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<float>("LayerThickness")
                        .HasPrecision(3, 1)
                        .HasColumnType("float");

                    b.Property<bool>("LayerVisibility")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("PenId")
                        .HasColumnType("int");

                    b.HasKey("LayerId");

                    b.HasIndex("DrawBoxId");

                    b.HasIndex("LayerName")
                        .IsUnique();

                    b.HasIndex("PenId");

                    b.ToTable("Layers");

                    b.HasData(
                        new
                        {
                            LayerId = 1,
                            DrawBoxId = 1,
                            LayerLock = false,
                            LayerName = "0",
                            LayerThickness = 1f,
                            LayerVisibility = false,
                            PenId = 1
                        },
                        new
                        {
                            LayerId = 2,
                            DrawBoxId = 1,
                            LayerLock = false,
                            LayerName = "a",
                            LayerThickness = 1f,
                            LayerVisibility = false,
                            PenId = 2
                        },
                        new
                        {
                            LayerId = 3,
                            DrawBoxId = 1,
                            LayerLock = false,
                            LayerName = "b",
                            LayerThickness = 1f,
                            LayerVisibility = false,
                            PenId = 1
                        });
                });

            modelBuilder.Entity("Draw.Entities.Concrete.Pen", b =>
                {
                    b.Property<int>("PenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PenBlue")
                        .HasColumnType("int");

                    b.Property<int>("PenGreen")
                        .HasColumnType("int");

                    b.Property<string>("PenName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PenRed")
                        .HasColumnType("int");

                    b.Property<int>("PenStyleId")
                        .HasColumnType("int");

                    b.Property<string>("PenUserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("PenId");

                    b.HasIndex("PenStyleId");

                    b.HasIndex("PenUserId");

                    b.ToTable("Pens");

                    b.HasData(
                        new
                        {
                            PenId = 1,
                            PenBlue = 10,
                            PenGreen = 10,
                            PenName = "pen1",
                            PenRed = 10,
                            PenStyleId = 1,
                            PenUserId = "b21972e1-742f-4fa7-be46-1189d9cab7ca"
                        },
                        new
                        {
                            PenId = 2,
                            PenBlue = 10,
                            PenGreen = 10,
                            PenName = "pen2",
                            PenRed = 10,
                            PenStyleId = 2,
                            PenUserId = "b21972e1-742f-4fa7-be46-1189d9cab7ca"
                        });
                });

            modelBuilder.Entity("Draw.Entities.Concrete.PenStyle", b =>
                {
                    b.Property<int>("PenStyleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PenStyleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PenStyleId");

                    b.ToTable("PenStyles");

                    b.HasData(
                        new
                        {
                            PenStyleId = 1,
                            PenStyleName = "solid"
                        },
                        new
                        {
                            PenStyleId = 2,
                            PenStyleName = "dot"
                        });
                });

            modelBuilder.Entity("Draw.Entities.Concrete.Point", b =>
                {
                    b.Property<int>("PointId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ElementId")
                        .HasColumnType("int");

                    b.Property<int>("PointTypeId")
                        .HasColumnType("int");

                    b.Property<double>("PointX")
                        .HasPrecision(10, 5)
                        .HasColumnType("double");

                    b.Property<double>("PointY")
                        .HasPrecision(10, 5)
                        .HasColumnType("double");

                    b.HasKey("PointId");

                    b.HasIndex("ElementId");

                    b.HasIndex("PointTypeId");

                    b.ToTable("Points");

                    b.HasData(
                        new
                        {
                            PointId = 1,
                            ElementId = 1,
                            PointTypeId = 1,
                            PointX = 10.0,
                            PointY = 8.0
                        },
                        new
                        {
                            PointId = 2,
                            ElementId = 1,
                            PointTypeId = 1,
                            PointX = 15.0,
                            PointY = 20.0
                        },
                        new
                        {
                            PointId = 3,
                            ElementId = 2,
                            PointTypeId = 1,
                            PointX = 5.0,
                            PointY = 10.0
                        },
                        new
                        {
                            PointId = 4,
                            ElementId = 2,
                            PointTypeId = 1,
                            PointX = 9.0,
                            PointY = 20.0
                        },
                        new
                        {
                            PointId = 5,
                            ElementId = 3,
                            PointTypeId = 1,
                            PointX = 7.0,
                            PointY = 3.0
                        },
                        new
                        {
                            PointId = 6,
                            ElementId = 3,
                            PointTypeId = 1,
                            PointX = 2.0,
                            PointY = 1.0
                        },
                        new
                        {
                            PointId = 7,
                            ElementId = 4,
                            PointTypeId = 2,
                            PointX = 0.0,
                            PointY = 0.0
                        });
                });

            modelBuilder.Entity("Draw.Entities.Concrete.PointType", b =>
                {
                    b.Property<int>("PointTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PointTypeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PointTypeId");

                    b.ToTable("PointTypes");

                    b.HasData(
                        new
                        {
                            PointTypeId = 1,
                            PointTypeName = "end"
                        },
                        new
                        {
                            PointTypeId = 2,
                            PointTypeName = "center"
                        },
                        new
                        {
                            PointTypeId = 3,
                            PointTypeName = "middle"
                        });
                });

            modelBuilder.Entity("Draw.Entities.Concrete.Radius", b =>
                {
                    b.Property<int>("RadiusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("RadiusElementId")
                        .HasColumnType("int");

                    b.Property<double>("RadiusValue")
                        .HasPrecision(8, 4)
                        .HasColumnType("double");

                    b.HasKey("RadiusId");

                    b.HasIndex("RadiusElementId");

                    b.ToTable("Radiuses");

                    b.HasData(
                        new
                        {
                            RadiusId = 1,
                            RadiusElementId = 4,
                            RadiusValue = 10.0
                        },
                        new
                        {
                            RadiusId = 2,
                            RadiusElementId = 4,
                            RadiusValue = 15.0
                        });
                });

            modelBuilder.Entity("Draw.Entities.Concrete.SSAngle", b =>
                {
                    b.Property<int>("SSAngleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("SSAngleElementId")
                        .HasColumnType("int");

                    b.Property<string>("SSAngleType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("SSAngleValue")
                        .HasPrecision(8, 4)
                        .HasColumnType("double");

                    b.HasKey("SSAngleId");

                    b.HasIndex("SSAngleElementId");

                    b.ToTable("SSAngles");

                    b.HasData(
                        new
                        {
                            SSAngleId = 1,
                            SSAngleElementId = 1,
                            SSAngleType = "start",
                            SSAngleValue = 0.0
                        },
                        new
                        {
                            SSAngleId = 2,
                            SSAngleElementId = 1,
                            SSAngleType = "stop",
                            SSAngleValue = 30.0
                        });
                });

            modelBuilder.Entity("Draw.Entities.Concrete.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "b21972e1-742f-4fa7-be46-1189d9cab7ca",
                            AccessFailedCount = 1,
                            ConcurrencyStamp = "9b80ad39-f83f-4728-a68a-01049b4fec03",
                            Email = "zahid11@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumber = "513",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "74481298-b788-44fe-969d-7513701361ca",
                            TwoFactorEnabled = false,
                            UserName = "zahid"
                        },
                        new
                        {
                            Id = "b21972e1-742f-4fa7-be46-1189d9cab7cb",
                            AccessFailedCount = 1,
                            ConcurrencyStamp = "e624472a-cad9-486b-8f6b-6a16009ae15b",
                            Email = "ali@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumber = "513",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "473b8260-f9b3-4d67-9b3b-51c5707cc8c7",
                            TwoFactorEnabled = false,
                            UserName = "ali"
                        },
                        new
                        {
                            Id = "b21972e1-742f-4fa7-be46-1189d9cab7cc",
                            AccessFailedCount = 1,
                            ConcurrencyStamp = "93a2434d-f259-4704-b24e-c935921b9d98",
                            Email = "zeynep@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumber = "513",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "9efba8a2-31aa-40c1-a9c0-24a05579cfb2",
                            TwoFactorEnabled = false,
                            UserName = "zeynep"
                        });
                });

            modelBuilder.Entity("Draw.Entities.Concrete.UserRefreshToken", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UserId");

                    b.ToTable("UserRefreshTokens");
                });

            modelBuilder.Entity("Draw.Entities.Concrete.UserRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "80ec254c-d039-48eb-a61a-798b90b1a304",
                            ConcurrencyStamp = "c9828c72-ad38-4a32-a5b8-bc7504104f87",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "961e2854-a5b9-4198-968a-60f457a256f3",
                            ConcurrencyStamp = "add28c77-48f6-47c6-84db-85a17f04ec72",
                            Name = "manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = "a6718d1b-104d-40a5-ba23-60b2a06a6948",
                            ConcurrencyStamp = "3ebbb2fd-e5ed-4f66-9969-ab44e2b7b046",
                            Name = "user",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Draw.Entities.Concrete.DrawBox", b =>
                {
                    b.HasOne("Draw.Entities.Concrete.User", "User")
                        .WithMany("DrawBoxs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Draw.Entities.Concrete.DrawCommand", b =>
                {
                    b.HasOne("Draw.Entities.Concrete.DrawBox", "DrawCommandDrawBox")
                        .WithMany("DrawCommands")
                        .HasForeignKey("DrawCommandDrawBoxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DrawCommandDrawBox");
                });

            modelBuilder.Entity("Draw.Entities.Concrete.Element", b =>
                {
                    b.HasOne("Draw.Entities.Concrete.ElementType", "ElementType")
                        .WithMany("Elements")
                        .HasForeignKey("ElementTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Draw.Entities.Concrete.Layer", "Layer")
                        .WithMany("Elements")
                        .HasForeignKey("LayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Draw.Entities.Concrete.Pen", "Pen")
                        .WithMany("Elements")
                        .HasForeignKey("PenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ElementType");

                    b.Navigation("Layer");

                    b.Navigation("Pen");
                });

            modelBuilder.Entity("Draw.Entities.Concrete.Layer", b =>
                {
                    b.HasOne("Draw.Entities.Concrete.DrawBox", "DrawBox")
                        .WithMany("Layers")
                        .HasForeignKey("DrawBoxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Draw.Entities.Concrete.Pen", "Pen")
                        .WithMany("Layers")
                        .HasForeignKey("PenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DrawBox");

                    b.Navigation("Pen");
                });

            modelBuilder.Entity("Draw.Entities.Concrete.Pen", b =>
                {
                    b.HasOne("Draw.Entities.Concrete.PenStyle", "PenStyle")
                        .WithMany("Pens")
                        .HasForeignKey("PenStyleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Draw.Entities.Concrete.User", "PenUser")
                        .WithMany("Pens")
                        .HasForeignKey("PenUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PenStyle");

                    b.Navigation("PenUser");
                });

            modelBuilder.Entity("Draw.Entities.Concrete.Point", b =>
                {
                    b.HasOne("Draw.Entities.Concrete.Element", "Element")
                        .WithMany("Points")
                        .HasForeignKey("ElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Draw.Entities.Concrete.PointType", "PointType")
                        .WithMany("PointTypePoints")
                        .HasForeignKey("PointTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Element");

                    b.Navigation("PointType");
                });

            modelBuilder.Entity("Draw.Entities.Concrete.Radius", b =>
                {
                    b.HasOne("Draw.Entities.Concrete.Element", "RadiusElement")
                        .WithMany("Radiuses")
                        .HasForeignKey("RadiusElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RadiusElement");
                });

            modelBuilder.Entity("Draw.Entities.Concrete.SSAngle", b =>
                {
                    b.HasOne("Draw.Entities.Concrete.Element", "SSAngleElement")
                        .WithMany("SSAngles")
                        .HasForeignKey("SSAngleElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SSAngleElement");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Draw.Entities.Concrete.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Draw.Entities.Concrete.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Draw.Entities.Concrete.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Draw.Entities.Concrete.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Draw.Entities.Concrete.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Draw.Entities.Concrete.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Draw.Entities.Concrete.DrawBox", b =>
                {
                    b.Navigation("DrawCommands");

                    b.Navigation("Layers");
                });

            modelBuilder.Entity("Draw.Entities.Concrete.Element", b =>
                {
                    b.Navigation("Points");

                    b.Navigation("Radiuses");

                    b.Navigation("SSAngles");
                });

            modelBuilder.Entity("Draw.Entities.Concrete.ElementType", b =>
                {
                    b.Navigation("Elements");
                });

            modelBuilder.Entity("Draw.Entities.Concrete.Layer", b =>
                {
                    b.Navigation("Elements");
                });

            modelBuilder.Entity("Draw.Entities.Concrete.Pen", b =>
                {
                    b.Navigation("Elements");

                    b.Navigation("Layers");
                });

            modelBuilder.Entity("Draw.Entities.Concrete.PenStyle", b =>
                {
                    b.Navigation("Pens");
                });

            modelBuilder.Entity("Draw.Entities.Concrete.PointType", b =>
                {
                    b.Navigation("PointTypePoints");
                });

            modelBuilder.Entity("Draw.Entities.Concrete.User", b =>
                {
                    b.Navigation("DrawBoxs");

                    b.Navigation("Pens");
                });
#pragma warning restore 612, 618
        }
    }
}
