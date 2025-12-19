using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    //public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    //{
    //    public void Configure(EntityTypeBuilder<Blog> builder)
    //    {
    //        builder.ToTable("Blogs");

    //        builder.HasKey(b => b.Id);

    //        builder.Property(b => b.Title)
    //            .IsRequired()
    //            .HasMaxLength(200);

    //        builder.Property(b => b.Url)
    //            .HasMaxLength(500);

    //        builder.HasIndex(b => b.Url).IsUnique();

    //        // 关系配置
    //        builder.HasOne(b => b.Author)
    //            .WithMany(u => u.Blogs)
    //            .HasForeignKey(b => b.AuthorId)
    //            .OnDelete(DeleteBehavior.Restrict);
    //    }
    //}
}
