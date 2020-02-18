using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHS.Infra.Data.Migrations
{
    public partial class addpermissionpath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Remark",
                table: "SHS.CMS.Permission",
                newName: "Path");

            migrationBuilder.InsertData(
                table: "SHS.CMS.Area",
                columns: new[] { "ID", "City", "CreateDate", "CreateUserId", "DeleteDate", "DeleteUserId", "IsDel", "Remarks", "Sort", "State", "Street", "UpdateDate", "UpdateUserId", "ZipCode" },
                values: new object[] { new Guid("922d74f6-898c-4aec-9bc1-c131fcab6c13"), "长沙", new DateTime(2020, 2, 17, 2, 41, 51, 863, DateTimeKind.Local).AddTicks(561), new Guid("af68b4f9-896e-41a6-92db-82009ebdbc59"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), 0, null, 0L, "中国", "解放西", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null });

            migrationBuilder.InsertData(
                table: "SHS.CMS.Role",
                columns: new[] { "ID", "CreateDate", "CreateUserId", "DeleteDate", "DeleteUserId", "IsDefault", "IsDel", "Name", "Remarks", "Sort", "Summary", "UpdateDate", "UpdateUserId" },
                values: new object[] { new Guid("2fbe8d77-c2a2-45ba-b39a-6363121a1578"), new DateTime(2020, 2, 17, 2, 41, 51, 862, DateTimeKind.Local).AddTicks(1005), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), false, 0, "系统管理员", "系统最高管理员", 0L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "SHS.CMS.User",
                columns: new[] { "ID", "Age", "AreaID", "CreateDate", "CreateUserId", "DeleteDate", "DeleteUserId", "DetailAddress", "Email", "IsDel", "Name", "Password", "Phone", "Remarks", "RoleID", "Sex", "Sort", "UpdateDate", "UpdateUserId" },
                values: new object[] { new Guid("af68b4f9-896e-41a6-92db-82009ebdbc59"), 0, new Guid("922d74f6-898c-4aec-9bc1-c131fcab6c13"), new DateTime(2020, 2, 17, 2, 41, 51, 863, DateTimeKind.Local).AddTicks(2811), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), 0, null, 0, "admin", "e1adc3949ba59abbe56e057f2f883e", null, "管理员", new Guid("2fbe8d77-c2a2-45ba-b39a-6363121a1578"), 0, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SHS.CMS.User",
                keyColumn: "ID",
                keyValue: new Guid("af68b4f9-896e-41a6-92db-82009ebdbc59"));

            migrationBuilder.DeleteData(
                table: "SHS.CMS.Area",
                keyColumn: "ID",
                keyValue: new Guid("922d74f6-898c-4aec-9bc1-c131fcab6c13"));

            migrationBuilder.DeleteData(
                table: "SHS.CMS.Role",
                keyColumn: "ID",
                keyValue: new Guid("2fbe8d77-c2a2-45ba-b39a-6363121a1578"));

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "SHS.CMS.Permission",
                newName: "Remark");

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
    }
}
