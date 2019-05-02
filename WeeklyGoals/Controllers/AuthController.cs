using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeeklyGoals.Models;
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
                var user = await _userSvc.AuthenticateExternalUser(externalId);

                if (user == null)
                {
                    var username = authResult.Principal.FindFirstValue(ClaimTypes.Name);
                    var email = authResult.Principal.FindFirstValue(ClaimTypes.Email);

                    user = await _userSvc.RegisterExternalUser(externalId, username, email);
                }

                var claims = new[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Username)
                };
                var identity = new ClaimsIdentity(claims);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);
            }

            return RedirectToAction("Index", "Home");
        }

        [Route("logout")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}