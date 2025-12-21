using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public User Author { get; set; }

        // 存储为JSON字符串
        public string TagsJson { get; set; }

        // 计算属性（不映射到数据库）
        [NotMapped]
        public List<string> Tags
        {
            get
            {
                try
                {
                    // 处理空值或空字符串
                    if (string.IsNullOrWhiteSpace(TagsJson))
                    {
                        return new List<string>();
                    }

                    // 安全地反序列化
                    var result = JsonSerializer.Deserialize<List<string>>(TagsJson);
                    return result ?? new List<string>();
                }
                catch (JsonException)
                {
                    // 如果JSON格式错误，返回空列表
                    return new List<string>();
                }
            }
            set
            {
                if (value == null)
                {
                    TagsJson = "[]";
                }
                else
                {
                    TagsJson = JsonSerializer.Serialize(value);
                }
            }
        }
    }
}
