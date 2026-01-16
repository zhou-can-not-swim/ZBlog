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
        Task<Blog> GetById(int id);

        //添加文章
        void AddBlogByContent(string content);
        void AddByTitleDespContent(Blog blog);
        void AddByTitleDespContentTag(Blog blog);

        void UpdateByTitleDespContentTag(Blog blog);


        //删除文章
        Task<Boolean> DeleteBlogByIdAsync(int id);


    }
}
