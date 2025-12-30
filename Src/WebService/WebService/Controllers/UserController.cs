using Common;
using Entities;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service;
using System.Threading.Tasks;

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

        [HttpGet()]
        public async Task<ApiResponse<User>> GetUser([FromQuery]int id)
        {
            try
            {
                if (id <= 0)
                {
                    // 返回参数错误响应
                    return ApiResponse<User>.ErrorResult("ID必须大于0", (int)ApiCode.ParameterError);
                }

                var user =await _userService.GetById(id);
                // 返回成功响应（带数据）
                if (user != null)
                {
                    return ApiResponse<User>.SuccessResult(user);

                }
                else
                {
                    return ApiResponse<User>.ErrorResult("查无此人");
                }
            }
            catch (Exception ex)
            {
                // 返回异常响应
                return ApiResponse<User>.ErrorResult($"获取用户失败：{ex.Message}", (int)ApiCode.InternalServerError);
            }
        }

        [HttpPost()]
        public async Task<ApiResponse<User>> GetUserByUserName([FromBody] string username)
        {
            try
            {
                if (username == null||username==""){
                    // 返回参数错误响应
                    return ApiResponse<User>.ErrorResult("没有用户名", (int)ApiCode.ParameterError);
                }

                var user = await _userService.GetByUserName(username);
                // 返回成功响应（带数据）
                if (user != null)
                {
                    return ApiResponse<User>.SuccessResult(user);

                }
                else
                {
                    return ApiResponse<User>.ErrorResult("查无此人");
                }
            }
            catch (Exception ex)
            {
                // 返回异常响应
                return ApiResponse<User>.ErrorResult($"获取用户失败：{ex.Message}", (int)ApiCode.InternalServerError);
            }
        }

        [HttpPost("create")]
        public async Task<ApiResponse<User>> CreateUser([FromBody] UserNameAndPasswordToUserDto? user)
        {
            if (user is null ||
                string.IsNullOrWhiteSpace(user.UserName) ||
                string.IsNullOrWhiteSpace(user.Password))
            {
                return ApiResponse<User>.ErrorResult("不能为空", (int)ApiCode.InternalServerError);
            }
            // 检查用户名是否已存在
            var existingUser = _userService.GetByUserName(user.UserName);
            if (existingUser != null)
            {
                return ApiResponse<User>.ErrorResult("用户名已存在", (int)ApiCode.InternalServerError);
            }

            //// 创建新用户
            //string hash_pwd = PasswordHelper.HashPassword(user.Password);
            //user.Password = hash_pwd;
            //user.EmailAddress = email.EmailAddress;
            //User userEntity = _mapper.Map<User>(user);

            //_repository.User.CreateUser(userEntity);
            //await _repository.SaveChangesAsync();
            //UserNoTodoDto createdUser = _mapper.Map<UserNoTodoDto>(userEntity); // 使用 AutoMapper 更新用户实体
            //return createdUser;
            return ApiResponse<User>.ErrorResult("未实现", (int)ApiCode.InternalServerError);
        }

    }
}
