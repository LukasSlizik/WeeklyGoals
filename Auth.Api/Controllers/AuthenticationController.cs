using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : Controller
    {
        public AuthenticationController()
        {
        }

        [Route("index")]
        public ActionResult Index()
        {
            return Ok("authenticated");
        }

        [HttpGet]
        [Route("user")]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticateUser([FromQuery] string scope)
        {
            return Ok();
        }
    }
}
