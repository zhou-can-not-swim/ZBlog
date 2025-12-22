using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebService.Migrations
{
    /// <inheritdoc />
    public partial class i1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    motto = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Tags = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(596), "C#" },
                    { 2, new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(613), ".NET" },
                    { 3, new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(614), "ASP.NET Core" },
                    { 4, new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(615), "Entity Framework" },
                    { 5, new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(616), "MySQL" },
                    { 6, new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(617), "数据库" },
                    { 7, new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(618), "编程" },
                    { 8, new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(664), "教程" },
                    { 9, new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(665), "优化" },
                    { 10, new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(666), "Web API" },
                    { 11, new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(667), "RESTful" },
                    { 12, new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(668), "依赖注入" },
                    { 13, new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(669), "设计模式" },
                    { 14, new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(670), "ORM" },
                    { 15, new DateTime(2025, 12, 22, 10, 54, 2, 386, DateTimeKind.Local).AddTicks(670), "性能" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Username", "motto" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "admin", "路漫漫其修远兮，吾将上下而求索" },
                    { 2, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), "tech@example.com", "techwriter", "分享知识，传递价值" },
                    { 3, new DateTime(2024, 1, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), "dev@example.com", "devlover", "代码改变世界" }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Description", "Tags", "Title" },
                values: new object[,]
                {
                    { 1, 1, "# C# 10 新特性\n\nC# 10 带来了许多令人兴奋的新特性...", new DateTime(2024, 1, 10, 9, 30, 0, 0, DateTimeKind.Unspecified), "深入探讨 C# 10 带来的新功能和改进", "[\"C#\",\".NET\",\"\\u7F16\\u7A0B\"]", "C# 10 新特性详解" },
                    { 2, 2, "# Entity Framework Core 入门\n\nEF Core 是 .NET 平台下的 ORM 框架...", new DateTime(2024, 1, 12, 14, 20, 0, 0, DateTimeKind.Unspecified), "从零开始学习 EF Core 的基本用法", "[\"EF Core\",\"\\u6570\\u636E\\u5E93\",\"ORM\",\"\\u6559\\u7A0B\"]", "Entity Framework Core 入门指南" },
                    { 3, 1, "# Web API 最佳实践\n\n1. 使用依赖注入\n2. 实现异常处理中间件...", new DateTime(2024, 1, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), "构建高性能 Web API 的建议和技巧", "[\"ASP.NET Core\",\"Web API\",\"RESTful\"]", "ASP.NET Core Web API 最佳实践" },
                    { 4, 3, "# MySQL 优化\n\n## 索引优化\n\n合理创建索引可以显著提升查询性能...", new DateTime(2024, 1, 18, 16, 45, 0, 0, DateTimeKind.Unspecified), "提升 MySQL 数据库性能的实用方法", "[\"MySQL\",\"\\u6570\\u636E\\u5E93\",\"\\u4F18\\u5316\",\"\\u6027\\u80FD\"]", "MySQL 优化技巧" },
                    { 5, 2, "# 依赖注入详解\n\n依赖注入是现代 .NET 应用的核心模式...", new DateTime(2024, 1, 20, 13, 15, 0, 0, DateTimeKind.Unspecified), "掌握 .NET 依赖注入的核心概念和应用", "[\".NET\",\"\\u4F9D\\u8D56\\u6CE8\\u5165\",\"\\u8BBE\\u8BA1\\u6A21\\u5F0F\"]", ".NET 依赖注入深入理解" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AuthorId",
                table: "Blogs",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
