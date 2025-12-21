using EF;
using Entities;
using Service;
using Service.Impl;

namespace WebService.Impl
{
    public class BlogService : BaseService<Blog>, IBlogService
    {
        public BlogService(BlogDbContext dbContext) : base(dbContext)
        {
        }
    }
}
