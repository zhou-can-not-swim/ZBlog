using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    // Tag.cs
    public class Tag : BaseEntity
    {
        public string Name { get; set; }

        //// 反向导航属性（可选）
        //[JsonIgnore]
        //public List<Blog> Blogs { get; set; } = new();

    }
}
