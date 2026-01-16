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

            // 作者关系配置
            entity.HasOne(e => e.Author)
                .WithMany(u => u.Blogs);

            // 配置tag列表
            //entity.Property(e => e.TagsJson)
            //    .HasColumnName("Tags")
            //    .HasMaxLength(1000); // 存储JSON字符串

            ////外键列放在多方表中
            ////这写的是单向的1个blog对1个tag，
            ////会在Blog表中生成TagId外键,而不会对Tag表产生影响
            //entity.HasOne(e => e._Tag)
            //    .WithMany();

            //将单向的blog和tag的关系修改成1个blog对多个tag,tag为数组
            // 配置 JSON 列（MySQL 5.7+）
            entity.Property(e => e.TagIdsJson)
                .HasColumnName("TagIds") // 数据库列名
                .HasColumnType("json") // MySQL JSON 类型
                .HasDefaultValue("[]") // 默认值
                .HasConversion(
                    v => v,             // 写入数据库时的转换：属性值 -> 数据库值
                    v => v ?? "[]" // 处理 null 值// 从数据库读取时的转换：数据库值 -> 属性值
                );

            // 索引（如果需要查询性能）
            //entity.HasIndex(e => e.AuthorId);
            entity.HasIndex(e => e.CreatedAt);

            // 忽略导航属性
            entity.Ignore(e => e.TagIds);
            entity.Ignore(e => e.Tags);





            // 配置种子数据
            //            var blogs = new[]
            //            {
            //    new Blog
            //    {
            //        Id = 1,
            //        Title = "C# 10 新特性详解",
            //        Description = "深入探讨 C# 10 带来的新功能和改进",
            //        Content = "# C# 10 新特性\n\nC# 10 带来了许多令人兴奋的新特性，包括全局 using 指令、文件范围的命名空间、常量内插字符串等，极大提升了开发效率。",
            //        AuthorId = 1,
            //        TagId = 1, // 对应C#标签
            //        CreatedAt = new DateTime(2024, 1, 10, 9, 30, 0)
            //    },
            //    new Blog
            //    {
            //        Id = 2,
            //        Title = "Entity Framework Core 入门指南",
            //        Description = "从零开始学习 EF Core 的基本用法",
            //        Content = "# Entity Framework Core 入门\n\nEF Core 是 .NET 平台下的 ORM 框架，支持多种数据库提供程序，简化了数据访问层的开发工作。",
            //        AuthorId = 2,
            //        TagId = 3, // 对应EF Core标签
            //        CreatedAt = new DateTime(2024, 1, 12, 14, 20, 0)
            //    },
            //    new Blog
            //    {
            //        Id = 3,
            //        Title = "ASP.NET Core Web API 最佳实践",
            //        Description = "构建高性能 Web API 的建议和技巧",
            //        Content = "# Web API 最佳实践\n\n1. 使用依赖注入\n2. 实现异常处理中间件\n3. 添加请求验证\n4. 使用适当的 HTTP 状态码\n5. 实现缓存机制提升性能",
            //        AuthorId = 1,
            //        TagId = 4, // 对应ASP.NET Core标签
            //        CreatedAt = new DateTime(2024, 1, 15, 11, 0, 0)
            //    },
            //    new Blog
            //    {
            //        Id = 4,
            //        Title = "MySQL 优化技巧",
            //        Description = "提升 MySQL 数据库性能的实用方法",
            //        Content = "# MySQL 优化\n\n## 索引优化\n\n合理创建索引可以显著提升查询性能，但过多的索引会影响写入操作。本文详细讲解索引设计原则和优化方法。",
            //        AuthorId = 3,
            //        TagId = 5, // 对应数据库标签
            //        CreatedAt = new DateTime(2024, 1, 18, 16, 45, 0)
            //    },
            //    new Blog
            //    {
            //        Id = 5,
            //        Title = ".NET 依赖注入深入理解",
            //        Description = "掌握 .NET 依赖注入的核心概念和应用",
            //        Content = "# 依赖注入详解\n\n依赖注入是现代 .NET 应用的核心模式，通过控制反转(IoC)容器管理对象生命周期，提高代码的可测试性和可维护性。",
            //        AuthorId = 2,
            //        TagId = 2, // 对应.NET标签
            //        CreatedAt = new DateTime(2024, 1, 20, 13, 15, 0)
            //    },
            //    new Blog
            //    {
            //        Id = 6,
            //        Title = "异步编程在 C# 中的最佳实践",
            //        Description = "正确使用 async/await 提升应用响应能力",
            //        Content = "# 异步编程指南\n\n异步编程可以避免线程阻塞，提升应用吞吐量。本文讲解异步编程的核心原则、常见陷阱和性能优化技巧。",
            //        AuthorId = 1,
            //        TagId = 1, // 对应C#标签
            //        CreatedAt = new DateTime(2024, 1, 22, 10, 0, 0)
            //    },
            //    new Blog
            //    {
            //        Id = 7,
            //        Title = "ASP.NET Core 中间件开发详解",
            //        Description = "自定义中间件实现请求处理逻辑",
            //        Content = "# 中间件开发\n\n中间件是处理 HTTP 请求的组件管道，本文详细介绍如何创建、配置和使用自定义中间件，以及中间件的执行顺序。",
            //        AuthorId = 2,
            //        TagId = 4, // 对应ASP.NET Core标签
            //        CreatedAt = new DateTime(2024, 1, 25, 15, 30, 0)
            //    },
            //    new Blog
            //    {
            //        Id = 8,
            //        Title = "Redis 缓存在 .NET 中的应用",
            //        Description = "使用 Redis 提升 .NET 应用性能",
            //        Content = "# Redis 缓存实战\n\nRedis 是高性能的键值存储系统，本文讲解如何在 .NET 应用中集成 Redis、实现数据缓存和分布式锁。",
            //        AuthorId = 3,
            //        TagId = 2, // 对应.NET标签
            //        CreatedAt = new DateTime(2024, 1, 28, 9, 15, 0)
            //    },
            //    new Blog
            //    {
            //        Id = 9,
            //        Title = "C# 设计模式之单例模式",
            //        Description = "深入理解单例模式的多种实现方式",
            //        Content = "# 单例模式详解\n\n单例模式确保一个类只有一个实例，并提供全局访问点。本文对比懒汉式、饿汉式、双重检查锁定等多种实现方式的优缺点。",
            //        AuthorId = 1,
            //        TagId = 7, // 对应设计模式标签
            //        CreatedAt = new DateTime(2024, 2, 1, 14, 45, 0)
            //    },
            //    new Blog
            //    {
            //        Id = 10,
            //        Title = ".NET 6 性能优化技巧",
            //        Description = "提升 .NET 6 应用性能的实用方法",
            //        Content = "# .NET 6 性能调优\n\n.NET 6 带来了显著的性能提升，但合理的代码编写和配置仍然至关重要。本文分享内存管理、GC 优化和代码优化的实用技巧。",
            //        AuthorId = 2,
            //        TagId = 6, // 对应性能优化标签
            //        CreatedAt = new DateTime(2024, 2, 3, 11, 20, 0)
            //    },
            //    new Blog
            //    {
            //        Id = 11,
            //        Title = "EF Core 迁移和数据库版本控制",
            //        Description = "管理数据库架构变更的最佳实践",
            //        Content = "# EF Core 迁移\n\nEF Core 迁移允许你以代码优先的方式管理数据库架构变更，本文讲解迁移的创建、应用、回滚和团队协作技巧。",
            //        AuthorId = 3,
            //        TagId = 3, // 对应EF Core标签
            //        CreatedAt = new DateTime(2024, 2, 5, 16, 0, 0)
            //    },
            //    new Blog
            //    {
            //        Id = 12,
            //        Title = "ASP.NET Core 身份验证与授权",
            //        Description = "实现安全的用户认证和权限管理",
            //        Content = "# 身份验证与授权\n\n本文详细讲解如何在 ASP.NET Core 中实现 JWT 认证、基于角色和基于策略的授权，保护你的 Web 应用安全。",
            //        AuthorId = 1,
            //        TagId = 4, // 对应ASP.NET Core标签
            //        CreatedAt = new DateTime(2024, 2, 8, 9, 0, 0)
            //    },
            //    new Blog
            //    {
            //        Id = 13,
            //        Title = "LINQ 查询优化技巧",
            //        Description = "编写高性能的 LINQ 查询",
            //        Content = "# LINQ 性能优化\n\nLINQ 提供了强大的查询能力，但不当的使用会导致性能问题。本文讲解延迟执行、查询转换和避免常见性能陷阱的方法。",
            //        AuthorId = 2,
            //        TagId = 6, // 对应性能优化标签
            //        CreatedAt = new DateTime(2024, 2, 10, 13, 30, 0)
            //    },
            //    new Blog
            //    {
            //        Id = 14,
            //        Title = ".NET Core 配置管理最佳实践",
            //        Description = "灵活管理应用配置的方法",
            //        Content = "# 配置管理\n\n.NET Core 提供了统一的配置系统，支持多种配置源。本文讲解配置的加载、验证、热更新和环境特定配置的最佳实践。",
            //        AuthorId = 3,
            //        TagId = 9, // 对应配置管理标签
            //        CreatedAt = new DateTime(2024, 2, 12, 15, 45, 0)
            //    },
            //    new Blog
            //    {
            //        Id = 15,
            //        Title = "C# 委托和事件详解",
            //        Description = "理解委托、事件和回调的核心概念",
            //        Content = "# 委托与事件\n\n委托是类型安全的函数指针，事件是委托的特殊应用。本文通过实例讲解委托和事件的使用场景和实现原理。",
            //        AuthorId = 1,
            //        TagId = 1, // 对应C#标签
            //        CreatedAt = new DateTime(2024, 2, 15, 10, 15, 0)
            //    },
            //    new Blog
            //    {
            //        Id = 16,
            //        Title = "ASP.NET Core 日志记录最佳实践",
            //        Description = "构建完善的日志系统",
            //        Content = "# 日志记录指南\n\n良好的日志系统是排查问题的关键。本文讲解如何配置日志提供程序、设置日志级别、结构化日志和日志聚合的最佳实践。",
            //        AuthorId = 2,
            //        TagId = 4, // 对应ASP.NET Core标签
            //        CreatedAt = new DateTime(2024, 2, 18, 14, 0, 0)
            //    },
            //    new Blog
            //    {
            //        Id = 17,
            //        Title = "使用 xUnit 进行 .NET 单元测试",
            //        Description = "编写可靠的单元测试保障代码质量",
            //        Content = "# xUnit 单元测试\n\nxUnit 是 .NET 生态中主流的测试框架，本文讲解测试的基本原则、断言使用、测试夹具和数据驱动测试的实现方法。",
            //        AuthorId = 3,
            //        TagId = 8, // 对应测试标签
            //        CreatedAt = new DateTime(2024, 2, 20, 11, 30, 0)
            //    },
            //    new Blog
            //    {
            //        Id = 18,
            //        Title = ".NET 中的内存管理与垃圾回收",
            //        Description = "深入理解 CLR 内存管理机制",
            //        Content = "# 内存管理详解\n\n了解 .NET 垃圾回收器的工作原理、代龄机制、大对象堆和内存泄漏排查方法，帮助你编写更高效的代码。",
            //        AuthorId = 1,
            //        TagId = 6, // 对应性能优化标签
            //        CreatedAt = new DateTime(2024, 2, 22, 16, 15, 0)
            //    },
            //    new Blog
            //    {
            //        Id = 19,
            //        Title = "ASP.NET Core 跨域请求处理",
            //        Description = "解决 CORS 问题的完整指南",
            //        Content = "# CORS 配置\n\n跨域资源共享是现代 Web 应用的常见需求。本文详细讲解 CORS 原理、ASP.NET Core 中的配置方法和安全最佳实践。",
            //        AuthorId = 2,
            //        TagId = 4, // 对应ASP.NET Core标签
            //        CreatedAt = new DateTime(2024, 2, 25, 9, 45, 0)
            //    },
            //    new Blog
            //    {
            //        Id = 20,
            //        Title = ".NET 7 新特性与升级指南",
            //        Description = "从 .NET 6 迁移到 .NET 7 的注意事项",
            //        Content = "# .NET 7 升级指南\n\n.NET 7 带来了更多性能改进和新功能。本文讲解主要新特性、升级步骤、兼容性问题和最佳实践。",
            //        AuthorId = 3,
            //        TagId = 10, // 对应升级迁移标签
            //        CreatedAt = new DateTime(2024, 2, 28, 12, 0, 0)
            //    }
            //};


            //entity.HasData(blogs);

        }

    }
}
