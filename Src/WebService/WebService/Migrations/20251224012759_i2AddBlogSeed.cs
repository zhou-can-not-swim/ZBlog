using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebService.Migrations
{
    /// <inheritdoc />
    public partial class i2AddBlogSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Content",
                value: "# C# 10 新特性\n\nC# 10 带来了许多令人兴奋的新特性，包括全局 using 指令、文件范围的命名空间、常量内插字符串等，极大提升了开发效率。");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Content",
                value: "# Entity Framework Core 入门\n\nEF Core 是 .NET 平台下的 ORM 框架，支持多种数据库提供程序，简化了数据访问层的开发工作。");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Content",
                value: "# Web API 最佳实践\n\n1. 使用依赖注入\n2. 实现异常处理中间件\n3. 添加请求验证\n4. 使用适当的 HTTP 状态码\n5. 实现缓存机制提升性能");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "Content",
                value: "# MySQL 优化\n\n## 索引优化\n\n合理创建索引可以显著提升查询性能，但过多的索引会影响写入操作。本文详细讲解索引设计原则和优化方法。");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "Content",
                value: "# 依赖注入详解\n\n依赖注入是现代 .NET 应用的核心模式，通过控制反转(IoC)容器管理对象生命周期，提高代码的可测试性和可维护性。");

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Description", "Tags", "Title" },
                values: new object[,]
                {
                    { 6, 1, "# 异步编程指南\n\n异步编程可以避免线程阻塞，提升应用吞吐量。本文讲解异步编程的核心原则、常见陷阱和性能优化技巧。", new DateTime(2024, 1, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), "正确使用 async/await 提升应用响应能力", "[\"C#\",\"\\u5F02\\u6B65\\u7F16\\u7A0B\",\"\\u6027\\u80FD\\u4F18\\u5316\"]", "异步编程在 C# 中的最佳实践" },
                    { 7, 2, "# 中间件开发\n\n中间件是处理 HTTP 请求的组件管道，本文详细介绍如何创建、配置和使用自定义中间件，以及中间件的执行顺序。", new DateTime(2024, 1, 25, 15, 30, 0, 0, DateTimeKind.Unspecified), "自定义中间件实现请求处理逻辑", "[\"ASP.NET Core\",\"\\u4E2D\\u95F4\\u4EF6\",\"HTTP\",\"\\u7BA1\\u9053\"]", "ASP.NET Core 中间件开发详解" },
                    { 8, 3, "# Redis 缓存实战\n\nRedis 是高性能的键值存储系统，本文讲解如何在 .NET 应用中集成 Redis、实现数据缓存和分布式锁。", new DateTime(2024, 1, 28, 9, 15, 0, 0, DateTimeKind.Unspecified), "使用 Redis 提升 .NET 应用性能", "[\"Redis\",\"\\u7F13\\u5B58\",\".NET\",\"\\u6027\\u80FD\"]", "Redis 缓存在 .NET 中的应用" },
                    { 9, 1, "# 单例模式详解\n\n单例模式确保一个类只有一个实例，并提供全局访问点。本文对比懒汉式、饿汉式、双重检查锁定等多种实现方式的优缺点。", new DateTime(2024, 2, 1, 14, 45, 0, 0, DateTimeKind.Unspecified), "深入理解单例模式的多种实现方式", "[\"C#\",\"\\u8BBE\\u8BA1\\u6A21\\u5F0F\",\"\\u5355\\u4F8B\\u6A21\\u5F0F\"]", "C# 设计模式之单例模式" },
                    { 10, 2, "# .NET 6 性能调优\n\n.NET 6 带来了显著的性能提升，但合理的代码编写和配置仍然至关重要。本文分享内存管理、GC 优化和代码优化的实用技巧。", new DateTime(2024, 2, 3, 11, 20, 0, 0, DateTimeKind.Unspecified), "提升 .NET 6 应用性能的实用方法", "[\".NET 6\",\"\\u6027\\u80FD\\u4F18\\u5316\",\"\\u5185\\u5B58\\u7BA1\\u7406\"]", ".NET 6 性能优化技巧" },
                    { 11, 3, "# EF Core 迁移\n\nEF Core 迁移允许你以代码优先的方式管理数据库架构变更，本文讲解迁移的创建、应用、回滚和团队协作技巧。", new DateTime(2024, 2, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), "管理数据库架构变更的最佳实践", "[\"EF Core\",\"\\u6570\\u636E\\u5E93\\u8FC1\\u79FB\",\"\\u7248\\u672C\\u63A7\\u5236\"]", "EF Core 迁移和数据库版本控制" },
                    { 12, 1, "# 身份验证与授权\n\n本文详细讲解如何在 ASP.NET Core 中实现 JWT 认证、基于角色和基于策略的授权，保护你的 Web 应用安全。", new DateTime(2024, 2, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), "实现安全的用户认证和权限管理", "[\"ASP.NET Core\",\"\\u8BA4\\u8BC1\",\"\\u6388\\u6743\",\"JWT\"]", "ASP.NET Core 身份验证与授权" },
                    { 13, 2, "# LINQ 性能优化\n\nLINQ 提供了强大的查询能力，但不当的使用会导致性能问题。本文讲解延迟执行、查询转换和避免常见性能陷阱的方法。", new DateTime(2024, 2, 10, 13, 30, 0, 0, DateTimeKind.Unspecified), "编写高性能的 LINQ 查询", "[\"LINQ\",\"C#\",\"\\u6027\\u80FD\\u4F18\\u5316\",\"\\u67E5\\u8BE2\"]", "LINQ 查询优化技巧" },
                    { 14, 3, "# 配置管理\n\n.NET Core 提供了统一的配置系统，支持多种配置源。本文讲解配置的加载、验证、热更新和环境特定配置的最佳实践。", new DateTime(2024, 2, 12, 15, 45, 0, 0, DateTimeKind.Unspecified), "灵活管理应用配置的方法", "[\".NET Core\",\"\\u914D\\u7F6E\",\"\\u73AF\\u5883\\u53D8\\u91CF\",\"appsettings\"]", ".NET Core 配置管理最佳实践" },
                    { 15, 1, "# 委托与事件\n\n委托是类型安全的函数指针，事件是委托的特殊应用。本文通过实例讲解委托和事件的使用场景和实现原理。", new DateTime(2024, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), "理解委托、事件和回调的核心概念", "[\"C#\",\"\\u59D4\\u6258\",\"\\u4E8B\\u4EF6\",\"\\u56DE\\u8C03\"]", "C# 委托和事件详解" },
                    { 16, 2, "# 日志记录指南\n\n良好的日志系统是排查问题的关键。本文讲解如何配置日志提供程序、设置日志级别、结构化日志和日志聚合的最佳实践。", new DateTime(2024, 2, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), "构建完善的日志系统", "[\"ASP.NET Core\",\"\\u65E5\\u5FD7\",\"\\u8BCA\\u65AD\",\"Serilog\"]", "ASP.NET Core 日志记录最佳实践" },
                    { 17, 3, "# xUnit 单元测试\n\nxUnit 是 .NET 生态中主流的测试框架，本文讲解测试的基本原则、断言使用、测试夹具和数据驱动测试的实现方法。", new DateTime(2024, 2, 20, 11, 30, 0, 0, DateTimeKind.Unspecified), "编写可靠的单元测试保障代码质量", "[\"xUnit\",\"\\u5355\\u5143\\u6D4B\\u8BD5\",\".NET\",\"TDD\"]", "使用 xUnit 进行 .NET 单元测试" },
                    { 18, 1, "# 内存管理详解\n\n了解 .NET 垃圾回收器的工作原理、代龄机制、大对象堆和内存泄漏排查方法，帮助你编写更高效的代码。", new DateTime(2024, 2, 22, 16, 15, 0, 0, DateTimeKind.Unspecified), "深入理解 CLR 内存管理机制", "[\".NET\",\"\\u5185\\u5B58\\u7BA1\\u7406\",\"GC\",\"\\u6027\\u80FD\"]", ".NET 中的内存管理与垃圾回收" },
                    { 19, 2, "# CORS 配置\n\n跨域资源共享是现代 Web 应用的常见需求。本文详细讲解 CORS 原理、ASP.NET Core 中的配置方法和安全最佳实践。", new DateTime(2024, 2, 25, 9, 45, 0, 0, DateTimeKind.Unspecified), "解决 CORS 问题的完整指南", "[\"ASP.NET Core\",\"CORS\",\"\\u8DE8\\u57DF\",\"Web \\u5F00\\u53D1\"]", "ASP.NET Core 跨域请求处理" },
                    { 20, 3, "# .NET 7 升级指南\n\n.NET 7 带来了更多性能改进和新功能。本文讲解主要新特性、升级步骤、兼容性问题和最佳实践。", new DateTime(2024, 2, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "从 .NET 6 迁移到 .NET 7 的注意事项", "[\".NET 7\",\"\\u5347\\u7EA7\",\"\\u65B0\\u7279\\u6027\",\"\\u8FC1\\u79FB\"]", ".NET 7 新特性与升级指南" }
                });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 9, 27, 58, 627, DateTimeKind.Local).AddTicks(9622));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 9, 27, 58, 627, DateTimeKind.Local).AddTicks(9644));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 9, 27, 58, 627, DateTimeKind.Local).AddTicks(9647));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 9, 27, 58, 627, DateTimeKind.Local).AddTicks(9649));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 9, 27, 58, 627, DateTimeKind.Local).AddTicks(9651));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 9, 27, 58, 627, DateTimeKind.Local).AddTicks(9653));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 9, 27, 58, 627, DateTimeKind.Local).AddTicks(9655));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 9, 27, 58, 627, DateTimeKind.Local).AddTicks(9657));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 9, 27, 58, 627, DateTimeKind.Local).AddTicks(9659));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 9, 27, 58, 627, DateTimeKind.Local).AddTicks(9662));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 9, 27, 58, 627, DateTimeKind.Local).AddTicks(9664));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 9, 27, 58, 627, DateTimeKind.Local).AddTicks(9666));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 9, 27, 58, 627, DateTimeKind.Local).AddTicks(9669));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 9, 27, 58, 627, DateTimeKind.Local).AddTicks(9671));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 9, 27, 58, 627, DateTimeKind.Local).AddTicks(9673));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Content",
                value: "# C# 10 新特性\n\nC# 10 带来了许多令人兴奋的新特性...");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Content",
                value: "# Entity Framework Core 入门\n\nEF Core 是 .NET 平台下的 ORM 框架...");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Content",
                value: "# Web API 最佳实践\n\n1. 使用依赖注入\n2. 实现异常处理中间件...");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "Content",
                value: "# MySQL 优化\n\n## 索引优化\n\n合理创建索引可以显著提升查询性能...");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "Content",
                value: "# 依赖注入详解\n\n依赖注入是现代 .NET 应用的核心模式...");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(596));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(613));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(614));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(615));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(616));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(617));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(618));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(664));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(665));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(666));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(667));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(668));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(669));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(670));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(670));
        }
    }
}
