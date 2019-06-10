using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeeklyGoals.Models.Auth;
using WeeklyGoals.Services;

namespace WeeklyGoals.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IUserService _userSvc;

        public AuthController(IUserService userSvc)
        {
            _userSvc = userSvc;
        }

        [Route("login")]
        public IActionResult LogIn()
        {
            return View(new LogInModel());
        }

        [Route("login/{id}")]
        public Task LogIn(string id)
        {
            return HttpContext.ChallengeAsync(id, new AuthenticationProperties { RedirectUri = "/auth/signin" });
        }

        [Route("signin")]
        public async Task<IActionResult> SignIn()
        {
            var authResult = await HttpContext.AuthenticateAsync();
            
            if (authResult.Succeeded)
            {
                var externalId = authResult.Principal.FindFirstValue(ClaimTypes.NameIdentifier);

                if (!await _userSvc.IsExternalUserRegistered(externalId))
                {
                    var username = authResult.Principal.FindFirstValue(ClaimTypes.Name);
                    var email = authResult.Principal.FindFirstValue(ClaimTypes.Email);

                    await _userSvc.RegisterExternalUser(externalId, username, email);
                }
                await HttpContext.SignInAsync(authResult.Principal);
            }
            return RedirectToAction("Index", "Home");
        }

        [Route("signout")]
        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}