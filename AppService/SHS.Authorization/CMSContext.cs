using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SHS.Infra.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHS.Authorization
{
    public class CMSContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;uid=sa;pwd=123456;database=SHS.CMS;");
        }
    }
}
