using Common;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/blog/")]
    public class BlogController : Controller
    {

        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("all")]
        public async Task<ApiResponse<List<Blog>>> GetAllBlogs()
        {
            List<Blog> blogs =await _blogService.FindAll().ToListAsync(); // 添加Include显示输出blogs
            if (blogs != null)
            {
                return ApiResponse<List<Blog>>.SuccessResult(blogs);
            }
            else
            {
                return ApiResponse<List<Blog>>.ErrorResult("查找所有文章错误");
            }

        }

        [HttpGet()]
        public async Task<ApiResponse<Blog>> GetBlogById([FromQuery]int id)
        {
            var blog = await _blogService.GetById(id); // 添加Include显示输出blogs
            if (blog != null)
            {
                return ApiResponse<Blog>.SuccessResult(blog);
            }
            else
            {
                return ApiResponse<Blog>.ErrorResult("通过id查找的方式错误");
            }

        }
    }
}
