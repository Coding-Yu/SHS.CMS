﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SHS.Infra.Data;

namespace SHS.Infra.Data.Migrations
{
    [DbContext(typeof(CMSContext))]
    [Migration("20200214230925_add-role-Summary")]
    partial class addroleSummary
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SHS.Domain.Core.Area.Area", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<DateTime>("CreateDate");

                    b.Property<Guid>("CreateUserId");

                    b.Property<DateTime>("DeleteDate");

                    b.Property<Guid>("DeleteUserId");

                    b.Property<int>("IsDel");

                    b.Property<string>("Remarks");

                    b.Property<long>("Sort");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<Guid>("UpdateUserId");

                    b.Property<string>("ZipCode");

                    b.HasKey("ID");

                    b.ToTable("SHS.CMS.Area");

                    b.HasData(
                        new
                        {
                            ID = new Guid("610ff4ce-7c45-408b-b450-1959f9d488cd"),
                            City = "长沙",
                            CreateDate = new DateTime(2020, 2, 15, 7, 9, 25, 338, DateTimeKind.Local).AddTicks(6299),
                            CreateUserId = new Guid("2d6050e6-e0b3-41c9-929d-0eb9b7d0a542"),
                            DeleteDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeleteUserId = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsDel = 0,
                            Sort = 0L,
                            State = "中国",
                            Street = "解放西",
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateUserId = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("SHS.Domain.Core.Articles.Article", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateDate");

                    b.Property<Guid>("CreateUserId");

                    b.Property<DateTime>("DeleteDate");

                    b.Property<Guid>("DeleteUserId");

                    b.Property<int>("IsDel");

                    b.Property<string>("Remarks");

                    b.Property<long>("Sort");

                    b.Property<string>("SourceLink");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<Guid>("UpdateUserId");

                    b.HasKey("ID");

                    b.HasIndex("CategoryId");

                    b.ToTable("SHS.CMS.Article");
                });

            modelBuilder.Entity("SHS.Domain.Core.Categorys.Category", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<Guid>("CreateUserId");

                    b.Property<DateTime>("DeleteDate");

                    b.Property<Guid>("DeleteUserId");

                    b.Property<int>("IsDel");

                    b.Property<string>("Name");

                    b.Property<string>("Remarks");

                    b.Property<long>("Sort");

                    b.Property<string>("Summary");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<Guid>("UpdateUserId");

                    b.HasKey("ID");

                    b.ToTable("SHS.CMS.Category");
                });

            modelBuilder.Entity("SHS.Domain.Core.Permissions.Permission", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<Guid>("CreateUserId");

                    b.Property<DateTime>("DeleteDate");

                    b.Property<Guid>("DeleteUserId");

                    b.Property<int>("IsDel");

                    b.Property<string>("Name");

                    b.Property<string>("Remark");

                    b.Property<string>("Remarks");

                    b.Property<long>("Sort");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<Guid>("UpdateUserId");

                    b.HasKey("ID");

                    b.ToTable("SHS.CMS.Permission");
                });

            modelBuilder.Entity("SHS.Domain.Core.Permissions.RolePermission", b =>
                {
                    b.Property<Guid>("RoleId");

                    b.Property<Guid>("PermissionId");

                    b.Property<Guid>("ID");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("SHS.CMS.RolePermission");
                });

            modelBuilder.Entity("SHS.Domain.Core.Roles.Role", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<Guid>("CreateUserId");

                    b.Property<DateTime>("DeleteDate");

                    b.Property<Guid>("DeleteUserId");

                    b.Property<bool>("IsDefault");

                    b.Property<int>("IsDel");

                    b.Property<string>("Name");

                    b.Property<string>("Remarks");

                    b.Property<long>("Sort");

                    b.Property<string>("Summary");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<Guid>("UpdateUserId");

                    b.HasKey("ID");

                    b.ToTable("SHS.CMS.Role");

                    b.HasData(
                        new
                        {
                            ID = new Guid("a53a7bc2-ebfb-4562-bc2b-8f18da868c8c"),
                            CreateDate = new DateTime(2020, 2, 15, 7, 9, 25, 337, DateTimeKind.Local).AddTicks(7157),
                            CreateUserId = new Guid("00000000-0000-0000-0000-000000000000"),
                            DeleteDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeleteUserId = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsDefault = false,
                            IsDel = 0,
                            Name = "系统管理员",
                            Remarks = "系统最高管理员",
                            Sort = 0L,
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateUserId = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("SHS.Domain.Core.Tags.ArticleTag", b =>
                {
                    b.Property<Guid>("ArticleId");

                    b.Property<Guid>("TagId");

                    b.Property<Guid>("ID");

                    b.HasKey("ArticleId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("SHS.CMS.ArticleTag");
                });

            modelBuilder.Entity("SHS.Domain.Core.Tags.Tag", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<Guid>("CreateUserId");

                    b.Property<DateTime>("DeleteDate");

                    b.Property<Guid>("DeleteUserId");

                    b.Property<int>("IsDel");

                    b.Property<string>("Name");

                    b.Property<string>("Remarks");

                    b.Property<long>("Sort");

                    b.Property<string>("Summary");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<Guid>("UpdateUserId");

                    b.HasKey("ID");

                    b.ToTable("SHS.CMS.Tag");
                });

            modelBuilder.Entity("SHS.Infra.Data.Users.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<Guid>("AreaID");

                    b.Property<DateTime>("CreateDate");

                    b.Property<Guid>("CreateUserId");

                    b.Property<DateTime>("DeleteDate");

                    b.Property<Guid>("DeleteUserId");

                    b.Property<int>("DetailAddress");

                    b.Property<string>("Email");

                    b.Property<int>("IsDel");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<string>("Remarks");

                    b.Property<Guid>("RoleID");

                    b.Property<int>("Sex");

                    b.Property<long>("Sort");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<Guid>("UpdateUserId");

                    b.HasKey("ID");

                    b.HasIndex("AreaID");

                    b.HasIndex("RoleID");

                    b.ToTable("SHS.CMS.User");

                    b.HasData(
                        new
                        {
                            ID = new Guid("2d6050e6-e0b3-41c9-929d-0eb9b7d0a542"),
                            Age = 0,
                            AreaID = new Guid("610ff4ce-7c45-408b-b450-1959f9d488cd"),
                            CreateDate = new DateTime(2020, 2, 15, 7, 9, 25, 338, DateTimeKind.Local).AddTicks(8535),
                            CreateUserId = new Guid("00000000-0000-0000-0000-000000000000"),
                            DeleteDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeleteUserId = new Guid("00000000-0000-0000-0000-000000000000"),
                            DetailAddress = 0,
                            IsDel = 0,
                            Name = "admin",
                            Password = "e1adc3949ba59abbe56e057f2f883e",
                            Remarks = "管理员",
                            RoleID = new Guid("a53a7bc2-ebfb-4562-bc2b-8f18da868c8c"),
                            Sex = 0,
                            Sort = 0L,
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateUserId = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("SHS.Domain.Core.Articles.Article", b =>
                {
                    b.HasOne("SHS.Domain.Core.Categorys.Category", "Category")
                        .WithMany("Article")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SHS.Domain.Core.Permissions.RolePermission", b =>
                {
                    b.HasOne("SHS.Domain.Core.Permissions.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SHS.Domain.Core.Roles.Role", "role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SHS.Domain.Core.Tags.ArticleTag", b =>
                {
                    b.HasOne("SHS.Domain.Core.Articles.Article", "Article")
                        .WithMany("ArticleTag")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SHS.Domain.Core.Tags.Tag", "Tag")
                        .WithMany("ArticleTag")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SHS.Infra.Data.Users.User", b =>
                {
                    b.HasOne("SHS.Domain.Core.Area.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SHS.Domain.Core.Roles.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
