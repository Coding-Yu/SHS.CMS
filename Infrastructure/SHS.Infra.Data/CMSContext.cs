using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SHS.Domain.Core.Area;
using SHS.Domain.Core.Articles;
using SHS.Domain.Core.Categorys;
using SHS.Domain.Core.Permissions;
using SHS.Domain.Core.Roles;
using SHS.Domain.Core.Tags;
using SHS.Infra.Data.Users;
using SHS.Infrastructu.Encrypt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SHS.Infra.Data
{
    public class CMSContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Rolepermission> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<SHS.Domain.Core.Logger.Log> logs { get; set; }
        public CMSContext() { }
        public CMSContext(DbContextOptions<CMSContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(configuration["DBConfig:MSSQL:ConnectionString"]);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO 软删除映射https://github.com/scfido/softdelete/blob/master/MySQLDbContext.cs
            //modelBuilder.Entity<User>().Property<bool>("IsDelete");
            modelBuilder.Entity<User>(entity =>
            {
                entity
                .HasKey(u => u.ID);
            });
            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.role)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);

            modelBuilder.Entity<RolePermission>()
                 .HasOne(rp => rp.Permission)
                 .WithMany(r => r.RolePermissions)
                 .HasForeignKey(rp => rp.PermissionId);


            modelBuilder.Entity<ArticleTag>()
                .HasKey(at => new { at.ArticleId, at.TagId });

            modelBuilder.Entity<ArticleTag>()
                .HasOne(at => at.Article)
                .WithMany(a => a.ArticleTag)
                .HasForeignKey(at => at.ArticleId);

            modelBuilder.Entity<ArticleTag>()
                 .HasOne(at => at.Tag)
                 .WithMany(a => a.ArticleTag)
                 .HasForeignKey(at => at.TagId);
            var userId = Guid.NewGuid();
            var roleId = Guid.NewGuid();
            var areaId = Guid.NewGuid();
            modelBuilder.Entity<Rolepermission>().HasData(new Rolepermission { ID = roleId, Name = "系统管理员", CreateDate = DateTime.Now, Remarks = "系统最高管理员" });
            modelBuilder.Entity<Area>().HasData(new Area { ID = areaId, City = "长沙", CreateDate = DateTime.Now, Street = "解放西", CreateUserId = userId, State = "中国", Province = "湖南" });
            modelBuilder.Entity<User>().HasData(new User { ID = userId, Name = "admin", CreateDate = DateTime.Now, Password = MD5Encrypt.EncryptBy32("123456"), Remarks = "管理员", RoleID = roleId, AreaID = areaId, Email = "1076372177@qq.com", Icon = "https://tse1-mm.cn.bing.net/th?id=OIP.VWs6ip-0SNpR7Yof8YYfCgAAAA&w=152&h=160&c=8&rs=1&qlt=90&pid=3.1&rm=2" });
        }
    }

}
