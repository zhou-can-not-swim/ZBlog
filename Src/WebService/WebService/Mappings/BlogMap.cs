using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using System.Text.Json;

namespace EF.Mappings
{
    class BlogMap : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> entity)
        {

            // 配置 Blog 实体
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.Description)//最大1000字描述
                .IsRequired()
                .HasMaxLength(1000);

            // 关系配置
            entity.HasOne(e => e.Author)
                .WithMany(u => u.Blogs);

            // 配置tag列表
            entity.Property(e => e.TagsJson)
                .HasColumnName("Tags")
                .HasMaxLength(1000); // 存储JSON字符串


            // 配置种子数据
            var blogs = new[]
            {
                new Blog
                {
                    Id = 1,
                    Title = "C# 10 新特性详解",
                    Description = "深入探讨 C# 10 带来的新功能和改进",
                    Content = "# C# 10 新特性\n\nC# 10 带来了许多令人兴奋的新特性...",
                    AuthorId = 1,
                    TagsJson = JsonSerializer.Serialize(new List<string> { "C#", ".NET", "编程" }),
                    CreatedAt = new DateTime(2024, 1, 10, 9, 30, 0)
                },
                new Blog
                {
                    Id = 2,
                    Title = "Entity Framework Core 入门指南",
                    Description = "从零开始学习 EF Core 的基本用法",
                    Content = "# Entity Framework Core 入门\n\nEF Core 是 .NET 平台下的 ORM 框架...",
                    AuthorId = 2,
                    TagsJson = JsonSerializer.Serialize(new List<string> { "EF Core", "数据库", "ORM", "教程" }),
                    CreatedAt = new DateTime(2024, 1, 12, 14, 20, 0)
                },
                new Blog
                {
                    Id = 3,
                    Title = "ASP.NET Core Web API 最佳实践",
                    Description = "构建高性能 Web API 的建议和技巧",
                    Content = "# Web API 最佳实践\n\n1. 使用依赖注入\n2. 实现异常处理中间件...",
                    AuthorId = 1,
                    TagsJson = JsonSerializer.Serialize(new List<string> { "ASP.NET Core", "Web API", "RESTful" }),
                    CreatedAt = new DateTime(2024, 1, 15, 11, 0, 0)
                },
                new Blog
                {
                    Id = 4,
                    Title = "MySQL 优化技巧",
                    Description = "提升 MySQL 数据库性能的实用方法",
                    Content = "# MySQL 优化\n\n## 索引优化\n\n合理创建索引可以显著提升查询性能...",
                    AuthorId = 3,
                    TagsJson = JsonSerializer.Serialize(new List<string> { "MySQL", "数据库", "优化", "性能" }),
                    CreatedAt = new DateTime(2024, 1, 18, 16, 45, 0)
                },
                new Blog
                {
                    Id = 5,
                    Title = ".NET 依赖注入深入理解",
                    Description = "掌握 .NET 依赖注入的核心概念和应用",
                    Content = "# 依赖注入详解\n\n依赖注入是现代 .NET 应用的核心模式...",
                    AuthorId = 2,
                    TagsJson = JsonSerializer.Serialize(new List<string> { ".NET", "依赖注入", "设计模式" }),
                    CreatedAt = new DateTime(2024, 1, 20, 13, 15, 0)
                }
            };

            entity.HasData(blogs);

        }

    }
}
