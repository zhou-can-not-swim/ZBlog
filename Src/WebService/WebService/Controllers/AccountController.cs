using Entities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebService.Impl;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {

        private IConfiguration _configuration;
        private IUserService _userService;
        private ILogger<AccountController> _logger;
        public AccountController(IConfiguration configuration, IUserService userService, ILogger<AccountController> logger)
        {
            _configuration = configuration;
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            // 验证用户凭证
            _logger.LogInformation("尝试登录用户名：", model.Username,"密码：",model.Password);
            //获取用户名和密码进行验证，这里简化为只要不为空即通过
            var user = _userService.GetByUserName(model.Username);
            if (user.Result.Password != model.Password) { 
                _logger.LogWarning("登录失败，密码错误：", model.Username);
                return Unauthorized();
            }
            
            if (user != null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, model.Username),
                    new Claim(ClaimTypes.Role, model.Username),
                    new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                string? minutes = _configuration["Jwt:ExpireMinutes"];
                //安全转换，提供默认值
                if (!double.TryParse(minutes, out double expireMinutes))
                {
                    // 转换失败，使用默认值
                    expireMinutes = 60; // 默认60分钟
                }
                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(expireMinutes),
                    signingCredentials: creds);

                return Ok(new {username=user.Result.Username,email=user.Result.Email, token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            else
            {
                _logger.LogWarning("登录失败，用户名不存在：", model.Username);
                return Unauthorized();
            }     
        }

        [HttpGet("profile")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetUserProfile()
        {
            try
            {
                // 从token中获取用户名
                var username = User.Identity?.Name;
                if (string.IsNullOrEmpty(username))
                {
                    return Unauthorized();
                }

                // 使用用户名查询数据库
                var user = await _userService.GetByUserName(username);

                if (user == null)
                {
                    return NotFound("用户不存在");
                }

                // 返回用户数据（注意：不要返回密码等敏感信息）
                return Ok(new
                {
                    username = user.Username,
                    email = user.Email,
                    createAt = user.CreatedAt
 
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取用户资料失败");
                return StatusCode(500, "服务器内部错误");
            }
        }

        ////进阶版本
        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] LoginDto model)
        //{
        //    // 1. 基本验证
        //    if (string.IsNullOrEmpty(model.Username) ||
        //        string.IsNullOrEmpty(model.Password))
        //        return BadRequest("用户名和密码不能为空");

        //    // 2. 查询数据库验证用户
        //    var user = await _userService.AuthenticateAsync(model.Username, model.Password);
        //    if (user == null)
        //        return Unauthorized("用户名或密码错误");

        //    // 3. 根据实际用户信息创建claims
        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        //        new Claim(ClaimTypes.Name, user.Username),
        //        new Claim(ClaimTypes.Email, user.Email),
        //        new Claim(ClaimTypes.Role, user.Role) // 从数据库读取实际角色
        //    };

        //    // 4. 生成token（同上）
        //    // ...

        //    // 5. 返回token和用户信息
        //    return Ok(new
        //    {
        //        token = new JwtSecurityTokenHandler().WriteToken(token),
        //        expires = token.ValidTo,
        //        user = new { user.Id, user.Username, user.Email, user.Role }
        //    });
        //}

        [Authorize]
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // 对于 JWT，客户端只需要删除 token
            // 对于 Cookies：
            // await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok(new { message = "Logged out" });
        }
    }
}
