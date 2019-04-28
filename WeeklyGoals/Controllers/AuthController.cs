using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeeklyGoals.Models;

namespace WeeklyGoals.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
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
                await HttpContext.SignInAsync(authResult.Principal);

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