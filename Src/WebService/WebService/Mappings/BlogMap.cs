using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

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



        }

    }
}
