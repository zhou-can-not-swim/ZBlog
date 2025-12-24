using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebService.Migrations
{
    /// <inheritdoc />
    public partial class i3ChangeBlogTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Blogs");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "TagId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "TagId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "TagId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "TagId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "TagId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "TagId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 7,
                column: "TagId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 8,
                column: "TagId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 9,
                column: "TagId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 10,
                column: "TagId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 11,
                column: "TagId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 12,
                column: "TagId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 13,
                column: "TagId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 14,
                column: "TagId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 15,
                column: "TagId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 16,
                column: "TagId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 17,
                column: "TagId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 18,
                column: "TagId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 19,
                column: "TagId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 20,
                column: "TagId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 17, 5, 57, 942, DateTimeKind.Local).AddTicks(6441));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 17, 5, 57, 942, DateTimeKind.Local).AddTicks(6461));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 17, 5, 57, 942, DateTimeKind.Local).AddTicks(6464));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 17, 5, 57, 942, DateTimeKind.Local).AddTicks(6468));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 17, 5, 57, 942, DateTimeKind.Local).AddTicks(6470));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 17, 5, 57, 942, DateTimeKind.Local).AddTicks(6473));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 17, 5, 57, 942, DateTimeKind.Local).AddTicks(6476));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 17, 5, 57, 942, DateTimeKind.Local).AddTicks(6479));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 17, 5, 57, 942, DateTimeKind.Local).AddTicks(6482));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 17, 5, 57, 942, DateTimeKind.Local).AddTicks(6485));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 17, 5, 57, 942, DateTimeKind.Local).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 17, 5, 57, 942, DateTimeKind.Local).AddTicks(6490));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 17, 5, 57, 942, DateTimeKind.Local).AddTicks(6493));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 17, 5, 57, 942, DateTimeKind.Local).AddTicks(6496));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 17, 5, 57, 942, DateTimeKind.Local).AddTicks(6498));

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_TagId",
                table: "Blogs",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Tags_TagId",
                table: "Blogs",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Tags_TagId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_TagId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Blogs",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Tags",
                value: "[\"C#\",\".NET\",\"\\u7F16\\u7A0B\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Tags",
                value: "[\"EF Core\",\"\\u6570\\u636E\\u5E93\",\"ORM\",\"\\u6559\\u7A0B\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Tags",
                value: "[\"ASP.NET Core\",\"Web API\",\"RESTful\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "Tags",
                value: "[\"MySQL\",\"\\u6570\\u636E\\u5E93\",\"\\u4F18\\u5316\",\"\\u6027\\u80FD\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "Tags",
                value: "[\".NET\",\"\\u4F9D\\u8D56\\u6CE8\\u5165\",\"\\u8BBE\\u8BA1\\u6A21\\u5F0F\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "Tags",
                value: "[\"C#\",\"\\u5F02\\u6B65\\u7F16\\u7A0B\",\"\\u6027\\u80FD\\u4F18\\u5316\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 7,
                column: "Tags",
                value: "[\"ASP.NET Core\",\"\\u4E2D\\u95F4\\u4EF6\",\"HTTP\",\"\\u7BA1\\u9053\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 8,
                column: "Tags",
                value: "[\"Redis\",\"\\u7F13\\u5B58\",\".NET\",\"\\u6027\\u80FD\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 9,
                column: "Tags",
                value: "[\"C#\",\"\\u8BBE\\u8BA1\\u6A21\\u5F0F\",\"\\u5355\\u4F8B\\u6A21\\u5F0F\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 10,
                column: "Tags",
                value: "[\".NET 6\",\"\\u6027\\u80FD\\u4F18\\u5316\",\"\\u5185\\u5B58\\u7BA1\\u7406\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 11,
                column: "Tags",
                value: "[\"EF Core\",\"\\u6570\\u636E\\u5E93\\u8FC1\\u79FB\",\"\\u7248\\u672C\\u63A7\\u5236\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 12,
                column: "Tags",
                value: "[\"ASP.NET Core\",\"\\u8BA4\\u8BC1\",\"\\u6388\\u6743\",\"JWT\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 13,
                column: "Tags",
                value: "[\"LINQ\",\"C#\",\"\\u6027\\u80FD\\u4F18\\u5316\",\"\\u67E5\\u8BE2\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 14,
                column: "Tags",
                value: "[\".NET Core\",\"\\u914D\\u7F6E\",\"\\u73AF\\u5883\\u53D8\\u91CF\",\"appsettings\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 15,
                column: "Tags",
                value: "[\"C#\",\"\\u59D4\\u6258\",\"\\u4E8B\\u4EF6\",\"\\u56DE\\u8C03\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 16,
                column: "Tags",
                value: "[\"ASP.NET Core\",\"\\u65E5\\u5FD7\",\"\\u8BCA\\u65AD\",\"Serilog\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 17,
                column: "Tags",
                value: "[\"xUnit\",\"\\u5355\\u5143\\u6D4B\\u8BD5\",\".NET\",\"TDD\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 18,
                column: "Tags",
                value: "[\".NET\",\"\\u5185\\u5B58\\u7BA1\\u7406\",\"GC\",\"\\u6027\\u80FD\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 19,
                column: "Tags",
                value: "[\"ASP.NET Core\",\"CORS\",\"\\u8DE8\\u57DF\",\"Web \\u5F00\\u53D1\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 20,
                column: "Tags",
                value: "[\".NET 7\",\"\\u5347\\u7EA7\",\"\\u65B0\\u7279\\u6027\",\"\\u8FC1\\u79FB\"]");

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
    }
}
