using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EF
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        // 定义 DbSet,表名
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=127.0.0.1;port=3306;uid=root;pwd=123456;database=zblog",

                new MySqlServerVersion(new Version(8, 0, 44)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //属性之间关系的配置
            base.OnModelCreating(modelBuilder);

            // 应用所有配置
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            //// 全局配置,后续可以研究
            //ConfigureGlobalFilters(modelBuilder);
        }

    }



}
