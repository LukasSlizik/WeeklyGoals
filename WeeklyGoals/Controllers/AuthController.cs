﻿using System.Security.Claims;
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
                // has the user already an registered account ?
                // if not -> register
                var id = authResult.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
                var username = authResult.Principal.FindFirstValue(ClaimTypes.Name);
                var email = authResult.Principal.FindFirstValue(ClaimTypes.Email);
                var user = await _userSvc.AuthenticateExternal(id);

                if (user == null)
                    await _userSvc.AddExternal(id, username, email);

                await HttpContext.SignInAsync(authResult.Principal);
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