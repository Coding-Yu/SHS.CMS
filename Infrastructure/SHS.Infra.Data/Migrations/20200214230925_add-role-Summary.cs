using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHS.Infra.Data.Migrations
{
    public partial class addroleSummary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SHS.CMS.User",
                keyColumn: "ID",
                keyValue: new Guid("937f6ed9-c753-4305-8f87-beb98857ec6c"));

            migrationBuilder.DeleteData(
                table: "SHS.CMS.Area",
                keyColumn: "ID",
                keyValue: new Guid("ba1ae598-bb58-4450-acfc-dec4a69b98cb"));

            migrationBuilder.DeleteData(
                table: "SHS.CMS.Role",
                keyColumn: "ID",
                keyValue: new Guid("b2d78d2e-cfb4-4a21-8877-c7d91c1d60e4"));

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "SHS.CMS.Role",
                nullable: true);

            migrationBuilder.InsertData(
                table: "SHS.CMS.Area",
                columns: new[] { "ID", "City", "CreateDate", "CreateUserId", "DeleteDate", "DeleteUserId", "IsDel", "Remarks", "Sort", "State", "Street", "UpdateDate", "UpdateUserId", "ZipCode" },
                values: new object[] { new Guid("610ff4ce-7c45-408b-b450-1959f9d488cd"), "长沙", new DateTime(2020, 2, 15, 7, 9, 25, 338, DateTimeKind.Local).AddTicks(6299), new Guid("2d6050e6-e0b3-41c9-929d-0eb9b7d0a542"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), 0, null, 0L, "中国", "解放西", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null });

            migrationBuilder.InsertData(
                table: "SHS.CMS.Role",
                columns: new[] { "ID", "CreateDate", "CreateUserId", "DeleteDate", "DeleteUserId", "IsDefault", "IsDel", "Name", "Remarks", "Sort", "Summary", "UpdateDate", "UpdateUserId" },
                values: new object[] { new Guid("a53a7bc2-ebfb-4562-bc2b-8f18da868c8c"), new DateTime(2020, 2, 15, 7, 9, 25, 337, DateTimeKind.Local).AddTicks(7157), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), false, 0, "系统管理员", "系统最高管理员", 0L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "SHS.CMS.User",
                columns: new[] { "ID", "Age", "AreaID", "CreateDate", "CreateUserId", "DeleteDate", "DeleteUserId", "DetailAddress", "Email", "IsDel", "Name", "Password", "Phone", "Remarks", "RoleID", "Sex", "Sort", "UpdateDate", "UpdateUserId" },
                values: new object[] { new Guid("2d6050e6-e0b3-41c9-929d-0eb9b7d0a542"), 0, new Guid("610ff4ce-7c45-408b-b450-1959f9d488cd"), new DateTime(2020, 2, 15, 7, 9, 25, 338, DateTimeKind.Local).AddTicks(8535), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), 0, null, 0, "admin", "e1adc3949ba59abbe56e057f2f883e", null, "管理员", new Guid("a53a7bc2-ebfb-4562-bc2b-8f18da868c8c"), 0, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SHS.CMS.User",
                keyColumn: "ID",
                keyValue: new Guid("2d6050e6-e0b3-41c9-929d-0eb9b7d0a542"));

            migrationBuilder.DeleteData(
                table: "SHS.CMS.Area",
                keyColumn: "ID",
                keyValue: new Guid("610ff4ce-7c45-408b-b450-1959f9d488cd"));

            migrationBuilder.DeleteData(
                table: "SHS.CMS.Role",
                keyColumn: "ID",
                keyValue: new Guid("a53a7bc2-ebfb-4562-bc2b-8f18da868c8c"));

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "SHS.CMS.Role");

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
        }
    }
}
