using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    // Tag.cs
    public class Tag : BaseEntity
    {
        public string Name { get; set; }

        public Blog Blog { get; set; }
     }
}
