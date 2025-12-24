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

        public int TagId { get; set; }
        [JsonIgnore]
        public Tag _Tag { get; set; }

    }
}
