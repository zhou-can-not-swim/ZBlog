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
    class TagMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> entity)
        {

            // 配置 Blog 实体
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            // 配置种子数据
            var tags = new[]
            {
                new Tag { Id = 1, Name = "C#", CreatedAt = DateTime.Now },
                new Tag { Id = 2, Name = ".NET", CreatedAt = DateTime.Now },
                new Tag { Id = 3, Name = "ASP.NET Core", CreatedAt = DateTime.Now },
                new Tag { Id = 4, Name = "Entity Framework", CreatedAt = DateTime.Now },
                new Tag { Id = 5, Name = "MySQL", CreatedAt = DateTime.Now },
                new Tag { Id = 6, Name = "数据库", CreatedAt = DateTime.Now },
                new Tag { Id = 7, Name = "编程", CreatedAt = DateTime.Now },
                new Tag { Id = 8, Name = "教程", CreatedAt = DateTime.Now },
                new Tag { Id = 9, Name = "优化", CreatedAt = DateTime.Now },
                new Tag { Id = 10, Name = "Web API", CreatedAt = DateTime.Now },
                new Tag { Id = 11, Name = "RESTful", CreatedAt = DateTime.Now },
                new Tag { Id = 12, Name = "依赖注入", CreatedAt = DateTime.Now },
                new Tag { Id = 13, Name = "设计模式", CreatedAt = DateTime.Now },
                new Tag { Id = 14, Name = "ORM", CreatedAt = DateTime.Now },
                new Tag { Id = 15, Name = "性能", CreatedAt = DateTime.Now }
            };

            entity.HasData(tags);


        }

    }
}
