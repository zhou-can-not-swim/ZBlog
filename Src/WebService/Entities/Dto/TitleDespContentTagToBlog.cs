using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class TitleDespContentTagToBlog
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public List<int> TagIds { get; set; }
    }
}
