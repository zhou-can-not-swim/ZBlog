using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service;
using WebService.Utils;

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

        [HttpGet("all")]//通过jwt拿todos
        public IQueryable<User> GetAllUsers()
        {
            IQueryable<User> users = _userService.FindAll().Include(u => u.Blogs);  // 添加Include显示输出blogs
            //return new ApiResponse<users>();
            return users;
            
        }
    }
}
