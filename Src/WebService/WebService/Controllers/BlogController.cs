using Common;
using Entities;
using Entities.Dto;
using Mapster;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ILogger<BlogController> _logger;

        public BlogController(IBlogService blogService, ILogger<BlogController> logger)
        {
            _blogService = blogService;
            _logger = logger;
        }

        /// <summary>
        /// 获取全部blog
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 通过id获取blog
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 新增blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpPost("add")]
        public async Task<ApiResponse<Blog>> AddBlog([FromBody] TitleDespContentTagToBlog blog)
        {
            _logger.LogInformation(
                "新增博客文章 - 标题:{BlogTitle}, 简介:{DescLength}, 内容:{Content},标签：{tag}",
                blog.Title,
                blog.Description ?? "",
                blog.Content ?? "",
                blog.TagIds.ToString() ?? "[]"
            );

            var _blog = blog.Adapt<Blog>();

            // 方式1：如果 DTO 中有 TagIds 属性
            if (blog.TagIds != null && blog.TagIds.Any())
            {
                _blog.TagIds = blog.TagIds.ToList();
            }
            _blogService.AddByTitleDespContentTag(_blog);
            await _blogService.SaveChanges();

            _logger.LogInformation("博客文章创建成功 - 文章ID:{BlogId}", _blog.Id);

            return ApiResponse<Blog>.SuccessResult(_blog);

        }

        /// <summary>
        /// 更新blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpPost("update")]
        public async Task<ApiResponse<Blog>> UpdateBlog([FromBody] IdTitleDespContentTagToBlog blog)
        {
            
            _logger.LogInformation(
                "修改博客文章 - 标题:{BlogTitle}, 简介:{DescLength}, 内容:{Content},标签：{tag}",
                blog.Title,
                blog.Description ?? "",
                blog.Content ?? "",
                blog.TagIds.ToString() ?? "[]"
            );

            var _blog = blog.Adapt<Blog>();

            // 方式1：如果 DTO 中有 TagIds 属性
            if (blog.TagIds != null && blog.TagIds.Any())
            {
                _blog.TagIds = blog.TagIds.ToList();
            }
            _blogService.UpdateByTitleDespContentTag(_blog);
            await _blogService.SaveChanges();

            _logger.LogInformation("博客文章修改成功 - 文章ID:{BlogId}", _blog.Id);

            return ApiResponse<Blog>.SuccessResult(_blog);

        }

        /// <summary>
        /// 通过id删除blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpGet("delete")]
        public async Task<ApiResponse<Blog>> DeleteBlog([FromQuery] int id)
        {

            _logger.LogInformation(
                "删除id为{id}的文章",
                id
            );

            bool result =await _blogService.DeleteBlogByIdAsync(id);
            
            if (result)
            {
                _logger.LogInformation("博客文章修改成功 - 文章ID:{BlogId}", id);
                await _blogService.SaveChanges();
                return ApiResponse<Blog>.SuccessResult(null,"删除成功");


            }
            else {
                _logger.LogError("出现与数据库操作相关的错误，博客文章删除失败 - 文章ID:{BlogId}", id);
                return ApiResponse<Blog>.ErrorResult("删除失败",404,null);
            }


        }


    }
}
