using Entities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {

        private IConfiguration _configuration;
        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            // 验证用户凭证
            if (model.Username != null || model.Password != null)
            {
                var claims = new[]
                {
                new Claim(ClaimTypes.Name, model.Username),
                new Claim(ClaimTypes.Role, "User"),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    _configuration["Jwt:Key"]));
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

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return Unauthorized();
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
