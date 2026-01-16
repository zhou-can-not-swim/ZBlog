using EF;
using Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Service;
using Service.Impl;
using System.Reflection.Metadata.Ecma335;

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


        public void AddBlogByContent(string content)
        {
            Create(new Blog { Content = content });
        }

        public void AddByTitleDespContent(Blog blog)
        {
            Create(blog);
        }

        public void AddByTitleDespContentTag(Blog blog)
        {
            Create(blog);
        }

        public void UpdateByTitleDespContentTag(Blog blog)
        {
            Update(blog);
        }

        public async Task<Boolean> DeleteBlogByIdAsync(int id)
        {
            try
            {
                Blog? blog = await FindByCondition(b => b.Id == id).FirstOrDefaultAsync();
                if (blog != null)
                {
                    Delete(blog);
                    return true;
                }
                else
                {
                    return false;
                }
                
                
            }
            catch (Exception ex) { 
                return false;
            }
            
            
        }
    }
}
