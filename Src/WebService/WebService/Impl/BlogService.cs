using EF;
using Entities;
using Microsoft.EntityFrameworkCore;
using Service;
using Service.Impl;

namespace WebService.Impl
{
    public class BlogService : BaseService<Blog>, IBlogService
    {
        public BlogService(BlogDbContext dbContext) : base(dbContext)
        {
        }

        //得到所有博客
        public async Task<List<Blog>> GetAllBlogs()
        {
            List<Blog> blogs = await FindAll().ToListAsync();
            return blogs;
        }

        public async Task<Blog> GetById(int id)
        {
            return await FindByCondition(b => b.Id == id).FirstOrDefaultAsync();
        }
    }
}
