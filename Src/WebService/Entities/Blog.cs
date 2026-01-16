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

        public int AuthorId { get; set; } = 1;
        [JsonIgnore]
        public User Author { get; set; }

        ////之前版本,只有一个tagid
        //public int TagId { get; set; } = 1;
        //[JsonIgnore]//省略Api响应
        //public Tag _Tag { get; set; }

        // JSON 存储标签ID数组
        public string TagIdsJson { get; set; } = "[]"; // 默认空数组

        // 导航属性（计算属性，用于查询）
        [NotMapped] // 不映射到数据库
        public List<int> TagIds
        {
            get => string.IsNullOrEmpty(TagIdsJson)
                ? new List<int>()
                : JsonSerializer.Deserialize<List<int>>(TagIdsJson);
            set => TagIdsJson = JsonSerializer.Serialize(value ?? new List<int>());
        }

        // 导航属性到标签（多对多关系）
        [NotMapped]
        public List<Tag> Tags { get; set; } = new();



    }
}
