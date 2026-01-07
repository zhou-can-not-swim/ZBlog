using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/test/")]
    public class TestController : Controller
    {
        [HttpGet("public")]
        public IActionResult GetPublicData()
        {
            return Ok(new { message = "Public data" });
        }

        [Authorize(Roles ="admin")]
        [HttpGet("private")]
        public IActionResult GetPrivateData()
        {
            return Ok(new { message = "Private data" });
        }
    }
}
