using Common;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController:ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly ILogger<TagController> _logger;
        public TagController(ITagService tagService, ILogger<TagController> logger)
        {
            _tagService = tagService;
            _logger = logger;
        }



        [HttpGet("all")]
        public async Task<ApiResponse<List<Tag>>> GetAllBlogs()
        {
            List<Tag> tags = await _tagService.FindAll().ToListAsync(); 
            if (tags != null)
            {
                return ApiResponse<List<Tag>>.SuccessResult(tags);
            }
            else
            {
                return ApiResponse<List<Tag>>.ErrorResult("查找所有标签错误");
            }

        }

    }
}
