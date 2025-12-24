using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IBlogService:IBaseService<Blog>
    {
        Task<List<Blog>> GetAllBlogs();
    }
}
