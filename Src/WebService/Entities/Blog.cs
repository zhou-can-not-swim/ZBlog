using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


        public ICollection<Tag> Tags { get; set; }
    }
}
