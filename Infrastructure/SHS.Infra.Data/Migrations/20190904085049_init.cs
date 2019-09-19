﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHS.Infra.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SHS.CMS.Area",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Sort = table.Column<long>(nullable: false),
                    IsDel = table.Column<int>(nullable: false),
                    CreateUserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<Guid>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeleteUserId = table.Column<Guid>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHS.CMS.Area", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SHS.CMS.Category",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Sort = table.Column<long>(nullable: false),
                    IsDel = table.Column<int>(nullable: false),
                    CreateUserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<Guid>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeleteUserId = table.Column<Guid>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHS.CMS.Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SHS.CMS.Permission",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Sort = table.Column<long>(nullable: false),
                    IsDel = table.Column<int>(nullable: false),
                    CreateUserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<Guid>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeleteUserId = table.Column<Guid>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHS.CMS.Permission", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SHS.CMS.Role",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Sort = table.Column<long>(nullable: false),
                    IsDel = table.Column<int>(nullable: false),
                    CreateUserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<Guid>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeleteUserId = table.Column<Guid>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHS.CMS.Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SHS.CMS.Tag",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Sort = table.Column<long>(nullable: false),
                    IsDel = table.Column<int>(nullable: false),
                    CreateUserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<Guid>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeleteUserId = table.Column<Guid>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHS.CMS.Tag", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SHS.CMS.Article",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Sort = table.Column<long>(nullable: false),
                    IsDel = table.Column<int>(nullable: false),
                    CreateUserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<Guid>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeleteUserId = table.Column<Guid>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    SourceLink = table.Column<string>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHS.CMS.Article", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SHS.CMS.Article_SHS.CMS.Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "SHS.CMS.Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SHS.CMS.RolePermission",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    PermissionId = table.Column<Guid>(nullable: false),
                    ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHS.CMS.RolePermission", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_SHS.CMS.RolePermission_SHS.CMS.Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "SHS.CMS.Permission",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SHS.CMS.RolePermission_SHS.CMS.Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SHS.CMS.Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SHS.CMS.User",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Sort = table.Column<long>(nullable: false),
                    IsDel = table.Column<int>(nullable: false),
                    CreateUserId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<Guid>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeleteUserId = table.Column<Guid>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    DetailAddress = table.Column<int>(nullable: false),
                    RoleID = table.Column<Guid>(nullable: false),
                    AreaID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHS.CMS.User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SHS.CMS.User_SHS.CMS.Area_AreaID",
                        column: x => x.AreaID,
                        principalTable: "SHS.CMS.Area",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SHS.CMS.User_SHS.CMS.Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "SHS.CMS.Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SHS.CMS.ArticleTag",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(nullable: false),
                    TagId = table.Column<Guid>(nullable: false),
                    ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHS.CMS.ArticleTag", x => new { x.ArticleId, x.TagId });
                    table.ForeignKey(
                        name: "FK_SHS.CMS.ArticleTag_SHS.CMS.Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "SHS.CMS.Article",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SHS.CMS.ArticleTag_SHS.CMS.Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "SHS.CMS.Tag",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SHS.CMS.Area",
                columns: new[] { "ID", "City", "CreateDate", "CreateUserId", "DeleteDate", "DeleteUserId", "IsDel", "Remarks", "Sort", "State", "Street", "UpdateDate", "UpdateUserId", "ZipCode" },
                values: new object[] { new Guid("ba1ae598-bb58-4450-acfc-dec4a69b98cb"), "长沙", new DateTime(2019, 9, 4, 16, 50, 49, 213, DateTimeKind.Local).AddTicks(7367), new Guid("937f6ed9-c753-4305-8f87-beb98857ec6c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), 0, null, 0L, "中国", "解放西", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null });

            migrationBuilder.InsertData(
                table: "SHS.CMS.Role",
                columns: new[] { "ID", "CreateDate", "CreateUserId", "DeleteDate", "DeleteUserId", "IsDefault", "IsDel", "Name", "Remarks", "Sort", "UpdateDate", "UpdateUserId" },
                values: new object[] { new Guid("b2d78d2e-cfb4-4a21-8877-c7d91c1d60e4"), new DateTime(2019, 9, 4, 16, 50, 49, 212, DateTimeKind.Local).AddTicks(5167), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), false, 0, "系统管理员", "系统最高管理员", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "SHS.CMS.User",
                columns: new[] { "ID", "Age", "AreaID", "CreateDate", "CreateUserId", "DeleteDate", "DeleteUserId", "DetailAddress", "Email", "IsDel", "Name", "Password", "Phone", "Remarks", "RoleID", "Sex", "Sort", "UpdateDate", "UpdateUserId" },
                values: new object[] { new Guid("937f6ed9-c753-4305-8f87-beb98857ec6c"), 0, new Guid("ba1ae598-bb58-4450-acfc-dec4a69b98cb"), new DateTime(2019, 9, 4, 16, 50, 49, 213, DateTimeKind.Local).AddTicks(9533), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), 0, null, 0, "admin", "e1adc3949ba59abbe56e057f2f883e", null, "管理员", new Guid("b2d78d2e-cfb4-4a21-8877-c7d91c1d60e4"), 0, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.CreateIndex(
                name: "IX_SHS.CMS.Article_CategoryId",
                table: "SHS.CMS.Article",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SHS.CMS.ArticleTag_TagId",
                table: "SHS.CMS.ArticleTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_SHS.CMS.RolePermission_PermissionId",
                table: "SHS.CMS.RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_SHS.CMS.User_AreaID",
                table: "SHS.CMS.User",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "IX_SHS.CMS.User_RoleID",
                table: "SHS.CMS.User",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHS.CMS.ArticleTag");

            migrationBuilder.DropTable(
                name: "SHS.CMS.RolePermission");

            migrationBuilder.DropTable(
                name: "SHS.CMS.User");

            migrationBuilder.DropTable(
                name: "SHS.CMS.Article");

            migrationBuilder.DropTable(
                name: "SHS.CMS.Tag");

            migrationBuilder.DropTable(
                name: "SHS.CMS.Permission");

            migrationBuilder.DropTable(
                name: "SHS.CMS.Area");

            migrationBuilder.DropTable(
                name: "SHS.CMS.Role");

            migrationBuilder.DropTable(
                name: "SHS.CMS.Category");
        }
    }
}
