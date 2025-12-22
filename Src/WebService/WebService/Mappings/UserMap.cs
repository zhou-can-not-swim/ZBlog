using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Mappings
{
    class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.motto)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasMany(e => e.Blogs).WithOne(e => e.Author);
            // 配置种子数据
            var users = new[]
            {
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@example.com",
                    motto = "路漫漫其修远兮，吾将上下而求索",
                    CreatedAt = new DateTime(2024, 1, 1, 8, 0, 0)
                },
                new User
                {
                    Id = 2,
                    Username = "techwriter",
                    Email = "tech@example.com",
                    motto = "分享知识，传递价值",
                    CreatedAt = new DateTime(2024, 1, 2, 10, 0, 0)
                },
                new User
                {
                    Id = 3,
                    Username = "devlover",
                    Email = "dev@example.com",
                    motto = "代码改变世界",
                    CreatedAt = new DateTime(2024, 1, 3, 14, 0, 0)
                }
            };

            entity.HasData(users);

        }

    }
}
