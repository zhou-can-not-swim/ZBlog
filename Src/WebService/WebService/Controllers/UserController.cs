using Common;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/user/")]
    public class UserController : Controller
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpGet("all")]//通过jwt拿todos
        //public async Task<IHttpActionResult> GetAllUsers()
        //{
        //    IQueryable<User> users = _userService.FindAll().Include(u => u.Blogs);  // 添加Include显示输出blogs
        //    //return new ApiResponse<users>();
        //    return users;
            
        //}

        [HttpGet("{id}")]
        public ApiResponse<User> GetUser(int id)
        {
            try
            {
                if (id <= 0)
                {
                    // 返回参数错误响应
                    return ApiResponse<User>.ErrorResult("ID必须大于0", (int)ApiCode.ParameterError);
                }

                // 模拟业务逻辑获取数据
                var user = new User { Id = 1, Username = "张三", Email = "zhangsan@example.com" };

                // 返回成功响应（带数据）
                return ApiResponse<User>.SuccessResult(user);
            }
            catch (Exception ex)
            {
                // 返回异常响应
                return ApiResponse<User>.ErrorResult($"获取用户失败：{ex.Message}", (int)ApiCode.InternalServerError);
            }
        }
    }
}
