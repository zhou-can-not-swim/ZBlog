using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entities
{
    // Blog.cs
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }

        // 存储为JSON字符串
        public string TagsJson { get; set; }

        // 计算属性（不映射到数据库）
        [NotMapped]
        public List<string> Tags
        {
            get => JsonSerializer.Deserialize<List<string>>(TagsJson ?? "[]");
            set => TagsJson = JsonSerializer.Serialize(value);
        }
    }
}
