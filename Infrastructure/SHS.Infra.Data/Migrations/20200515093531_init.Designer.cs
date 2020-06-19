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
    [Migration("20200515093531_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SHS.Domain.Core.Area.Area", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DeleteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IsDel")
                        .HasColumnType("int");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Sort")
                        .HasColumnType("bigint");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("SHS.CMS.Area");

                    b.HasData(
                        new
                        {
                            ID = new Guid("a122c40d-1bc0-4dcf-be5e-8e2536ab4637"),
                            City = "长沙",
                            CreateDate = new DateTime(2020, 5, 15, 17, 35, 31, 136, DateTimeKind.Local).AddTicks(526),
                            CreateUserId = new Guid("d118665a-3e55-49f0-a74c-57710133025b"),
                            DeleteDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeleteUserId = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsDel = 0,
                            Province = "湖南",
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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DeleteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IsDel")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Sort")
                        .HasColumnType("bigint");

                    b.Property<string>("SourceLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("CategoryId");

                    b.ToTable("SHS.CMS.Article");
                });

            modelBuilder.Entity("SHS.Domain.Core.Categorys.Category", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DeleteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IsDel")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Sort")
                        .HasColumnType("bigint");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("SHS.CMS.Category");
                });

            modelBuilder.Entity("SHS.Domain.Core.Logger.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Exception")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Logged")
                        .HasColumnType("datetime2");

                    b.Property<string>("MachineIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MachineName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NetRequestMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NetRequestUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SHS.CMS.Logger");
                });

            modelBuilder.Entity("SHS.Domain.Core.Permissions.Permission", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DeleteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IsDel")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Sort")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("SHS.CMS.Permission");
                });

            modelBuilder.Entity("SHS.Domain.Core.Permissions.RolePermission", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("SHS.CMS.RolePermission");
                });

            modelBuilder.Entity("SHS.Domain.Core.Roles.Rolepermission", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DeleteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<int>("IsDel")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Sort")
                        .HasColumnType("bigint");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("SHS.CMS.Role");

                    b.HasData(
                        new
                        {
                            ID = new Guid("e46774fa-9449-4bca-ab60-d6c9d3806449"),
                            CreateDate = new DateTime(2020, 5, 15, 17, 35, 31, 133, DateTimeKind.Local).AddTicks(8427),
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
                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ArticleId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("SHS.CMS.ArticleTag");
                });

            modelBuilder.Entity("SHS.Domain.Core.Tags.Tag", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DeleteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IsDel")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Sort")
                        .HasColumnType("bigint");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("SHS.CMS.Tag");
                });

            modelBuilder.Entity("SHS.Infra.Data.Users.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<Guid>("AreaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DeleteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DetailAddress")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsDel")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastLoginIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<long>("Sort")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("AreaID");

                    b.HasIndex("RoleID");

                    b.ToTable("SHS.CMS.User");

                    b.HasData(
                        new
                        {
                            ID = new Guid("d118665a-3e55-49f0-a74c-57710133025b"),
                            Age = 0,
                            AreaID = new Guid("a122c40d-1bc0-4dcf-be5e-8e2536ab4637"),
                            CreateDate = new DateTime(2020, 5, 15, 17, 35, 31, 136, DateTimeKind.Local).AddTicks(3348),
                            CreateUserId = new Guid("00000000-0000-0000-0000-000000000000"),
                            DeleteDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeleteUserId = new Guid("00000000-0000-0000-0000-000000000000"),
                            DetailAddress = 0,
                            Email = "1076372177@qq.com",
                            Icon = "https://tse1-mm.cn.bing.net/th?id=OIP.VWs6ip-0SNpR7Yof8YYfCgAAAA&w=152&h=160&c=8&rs=1&qlt=90&pid=3.1&rm=2",
                            IsDel = 0,
                            LastLoginDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "admin",
                            Password = "e1adc3949ba59abbe56e057f2f883e",
                            Remarks = "管理员",
                            RoleID = new Guid("e46774fa-9449-4bca-ab60-d6c9d3806449"),
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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHS.Domain.Core.Permissions.RolePermission", b =>
                {
                    b.HasOne("SHS.Domain.Core.Permissions.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SHS.Domain.Core.Roles.Rolepermission", "role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHS.Domain.Core.Tags.ArticleTag", b =>
                {
                    b.HasOne("SHS.Domain.Core.Articles.Article", "Article")
                        .WithMany("ArticleTag")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SHS.Domain.Core.Tags.Tag", "Tag")
                        .WithMany("ArticleTag")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHS.Infra.Data.Users.User", b =>
                {
                    b.HasOne("SHS.Domain.Core.Area.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SHS.Domain.Core.Roles.Rolepermission", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}