using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asset_Tracking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetCategory",
                columns: table => new
                {
                    AssetCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetCategoryName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetCategory", x => x.AssetCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "AssetImage",
                columns: table => new
                {
                    AssetImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetImage", x => x.AssetImageId);
                });

            migrationBuilder.CreateTable(
                name: "AssetStatus",
                columns: table => new
                {
                    AssetStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetStatusName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetStatus", x => x.AssetStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.BuildingId);
                });

            migrationBuilder.CreateTable(
                name: "Floor",
                columns: table => new
                {
                    FloorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floor", x => x.FloorId);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceStatus",
                columns: table => new
                {
                    MaintenanceStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceStatus", x => x.MaintenanceStatusId);
                });

            migrationBuilder.CreateTable(
                name: "RepairStatus",
                columns: table => new
                {
                    RepairStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepairStatusName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairStatus", x => x.RepairStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    OtherName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TechMail = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SiteId = table.Column<int>(type: "int", nullable: true),
                    BuildingId = table.Column<int>(type: "int", nullable: true),
                    FloorId = table.Column<int>(type: "int", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: true),
                    HasRoom = table.Column<bool>(type: "bit", nullable: false),
                    RoomLocationDescription = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    TitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.TitleId);
                });

            migrationBuilder.CreateTable(
                name: "UserImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    TitleId = table.Column<int>(type: "int", nullable: true),
                    UserImageId = table.Column<int>(type: "int", nullable: true),
                    StaffId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiteHead",
                columns: table => new
                {
                    SiteheadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeadName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    HeadEmail = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    HeadPhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TitleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteHead", x => x.SiteheadId);
                    table.ForeignKey(
                        name: "FK_SiteHead_Title_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Title",
                        principalColumn: "TitleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    GeneratedRefreshToken = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userRoles",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_userRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    SiteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SiteDescription = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DigitalAddress = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteheadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.SiteId);
                    table.ForeignKey(
                        name: "FK_Site_SiteHead_SiteheadId",
                        column: x => x.SiteheadId,
                        principalTable: "SiteHead",
                        principalColumn: "SiteheadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    AssetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AssetDescription = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    PurchaseFrom = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    AssignedTo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    HasWarranty = table.Column<bool>(type: "bit", nullable: false),
                    WarrantyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    AssetCategoryId = table.Column<int>(type: "int", nullable: false),
                    AssetStatusId = table.Column<int>(type: "int", nullable: false),
                    AssetImageId = table.Column<int>(type: "int", nullable: false),
                    SiteId = table.Column<int>(type: "int", nullable: true),
                    BuildingId = table.Column<int>(type: "int", nullable: true),
                    FloorId = table.Column<int>(type: "int", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: true),
                    RoomLocationDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AssetTagId = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AssetConditionDescription = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    IsAssetInGoodCondition = table.Column<bool>(type: "bit", nullable: true),
                    IsRepairRequired = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.AssetId);
                    table.ForeignKey(
                        name: "FK_Asset_AssetCategory_AssetCategoryId",
                        column: x => x.AssetCategoryId,
                        principalTable: "AssetCategory",
                        principalColumn: "AssetCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_AssetImage_AssetImageId",
                        column: x => x.AssetImageId,
                        principalTable: "AssetImage",
                        principalColumn: "AssetImageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_AssetStatus_AssetStatusId",
                        column: x => x.AssetStatusId,
                        principalTable: "AssetStatus",
                        principalColumn: "AssetStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "BuildingId");
                    table.ForeignKey(
                        name: "FK_Asset_Floor_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floor",
                        principalColumn: "FloorId");
                    table.ForeignKey(
                        name: "FK_Asset_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId");
                    table.ForeignKey(
                        name: "FK_Asset_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "SiteId");
                });

            migrationBuilder.CreateTable(
                name: "SiteLocation",
                columns: table => new
                {
                    SiteLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SiteId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteLocation", x => x.SiteLocationId);
                    table.ForeignKey(
                        name: "FK_SiteLocation_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetCheckIn",
                columns: table => new
                {
                    AssetCheckInId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ReturnedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    StaffId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    SiteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetCheckIn", x => x.AssetCheckInId);
                    table.ForeignKey(
                        name: "FK_AssetCheckIn_Asset_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Asset",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetCheckIn_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "SiteId");
                    table.ForeignKey(
                        name: "FK_AssetCheckIn_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId");
                });

            migrationBuilder.CreateTable(
                name: "AssetCheckOut",
                columns: table => new
                {
                    AssetCheckOutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetCheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AssignedTo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    SiteId = table.Column<int>(type: "int", nullable: true),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    FloorId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    RoomLocationDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsConfirmedEmailSent = table.Column<bool>(type: "bit", nullable: false),
                    EmailSentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HasReceivedConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    HasReceivedConfirmedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSMSSent = table.Column<bool>(type: "bit", nullable: false),
                    SMSSentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetCheckOut", x => x.AssetCheckOutId);
                    table.ForeignKey(
                        name: "FK_AssetCheckOut_Asset_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Asset",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetCheckOut_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetCheckOut_Floor_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floor",
                        principalColumn: "FloorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetCheckOut_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetCheckOut_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "SiteId");
                    table.ForeignKey(
                        name: "FK_AssetCheckOut_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId");
                });

            migrationBuilder.CreateTable(
                name: "AssetDispose",
                columns: table => new
                {
                    AssetDisposeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisposeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisposeTo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    AssetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetDispose", x => x.AssetDisposeId);
                    table.ForeignKey(
                        name: "FK_AssetDispose_Asset_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Asset",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetEventHistory",
                columns: table => new
                {
                    AssetEventHistoryId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Event = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    StatusChangedFrom = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    StatusChangeTo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    LocationChangedFrom = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    LocationChangedTo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    SiteChangedFrom = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    SiteChangedTo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    AssignedFrom = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    AssignedTo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    AssetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetEventHistory", x => x.AssetEventHistoryId);
                    table.ForeignKey(
                        name: "FK_AssetEventHistory_Asset_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Asset",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetMaintenance",
                columns: table => new
                {
                    AssetMaintenanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintenanceTitle = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateSent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaintainedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    MaintenanceStatusId = table.Column<int>(type: "int", nullable: false),
                    AssetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetMaintenance", x => x.AssetMaintenanceId);
                    table.ForeignKey(
                        name: "FK_AssetMaintenance_Asset_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Asset",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetMaintenance_MaintenanceStatus_MaintenanceStatusId",
                        column: x => x.MaintenanceStatusId,
                        principalTable: "MaintenanceStatus",
                        principalColumn: "MaintenanceStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetRepair",
                columns: table => new
                {
                    AssetRepairId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepairTitle = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    RepairerName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    RepairerContactNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    DateCompleted = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RepairStatusId = table.Column<int>(type: "int", nullable: false),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    AssetReceiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceivedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetRepair", x => x.AssetRepairId);
                    table.ForeignKey(
                        name: "FK_AssetRepair_Asset_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Asset",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetRepair_RepairStatus_RepairStatusId",
                        column: x => x.RepairStatusId,
                        principalTable: "RepairStatus",
                        principalColumn: "RepairStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleRepair",
                columns: table => new
                {
                    ScheduleRepairId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RepairTitle = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    RepairerName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    RepairerContactNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    DateCompleted = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RepairStatusId = table.Column<int>(type: "int", nullable: false),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    IsScheduleApproved = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleRepair", x => x.ScheduleRepairId);
                    table.ForeignKey(
                        name: "FK_ScheduleRepair_Asset_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Asset",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleRepair_RepairStatus_RepairStatusId",
                        column: x => x.RepairStatusId,
                        principalTable: "RepairStatus",
                        principalColumn: "RepairStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetCategoryId",
                table: "Asset",
                column: "AssetCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetImageId",
                table: "Asset",
                column: "AssetImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetStatusId",
                table: "Asset",
                column: "AssetStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_BuildingId",
                table: "Asset",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_FloorId",
                table: "Asset",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_RoomId",
                table: "Asset",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_SiteId",
                table: "Asset",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCheckIn_AssetId",
                table: "AssetCheckIn",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCheckIn_SiteId",
                table: "AssetCheckIn",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCheckIn_StaffId",
                table: "AssetCheckIn",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCheckOut_AssetId",
                table: "AssetCheckOut",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCheckOut_BuildingId",
                table: "AssetCheckOut",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCheckOut_FloorId",
                table: "AssetCheckOut",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCheckOut_RoomId",
                table: "AssetCheckOut",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCheckOut_SiteId",
                table: "AssetCheckOut",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCheckOut_StaffId",
                table: "AssetCheckOut",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetDispose_AssetId",
                table: "AssetDispose",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetEventHistory_AssetId",
                table: "AssetEventHistory",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintenance_AssetId",
                table: "AssetMaintenance",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintenance_MaintenanceStatusId",
                table: "AssetMaintenance",
                column: "MaintenanceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetRepair_AssetId",
                table: "AssetRepair",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetRepair_RepairStatusId",
                table: "AssetRepair",
                column: "RepairStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleRepair_AssetId",
                table: "ScheduleRepair",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleRepair_RepairStatusId",
                table: "ScheduleRepair",
                column: "RepairStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_SiteheadId",
                table: "Site",
                column: "SiteheadId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteHead_TitleId",
                table: "SiteHead",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteLocation_SiteId",
                table: "SiteLocation",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userRoles_UserId",
                table: "userRoles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetCheckIn");

            migrationBuilder.DropTable(
                name: "AssetCheckOut");

            migrationBuilder.DropTable(
                name: "AssetDispose");

            migrationBuilder.DropTable(
                name: "AssetEventHistory");

            migrationBuilder.DropTable(
                name: "AssetMaintenance");

            migrationBuilder.DropTable(
                name: "AssetRepair");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "ScheduleRepair");

            migrationBuilder.DropTable(
                name: "SiteLocation");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserImages");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "userRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "MaintenanceStatus");

            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "RepairStatus");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AssetCategory");

            migrationBuilder.DropTable(
                name: "AssetImage");

            migrationBuilder.DropTable(
                name: "AssetStatus");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Floor");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropTable(
                name: "SiteHead");

            migrationBuilder.DropTable(
                name: "Title");
        }
    }
}
