using Entities;
using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 应用所有配置
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //// 全局配置,后续可以研究
            //ConfigureGlobalFilters(modelBuilder);
        }

        //private static void ConfigureGlobalFilters(ModelBuilder modelBuilder)
        //{
        //    // 自动为所有继承 BaseEntity 的实体添加软删除筛选器
        //    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        //    {
        //        if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
        //        {
        //            var parameter = Expression.Parameter(entityType.ClrType, "e");
        //            var property = Expression.Property(parameter, nameof(BaseEntity.IsDeleted));
        //            var condition = Expression.Equal(property, Expression.Constant(false));
        //            var lambda = Expression.Lambda(condition, parameter);

        //            modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
        //        }
        //    }
        //}
        }

    }
