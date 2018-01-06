using Microsoft.AspNetCore.Mvc;
using WeeklyGoals.Models;

namespace WeeklyGoals.Controllers
{
    public class ProgressController : Controller
    {
        private GoalsContext _ctx;

        public ProgressController(GoalsContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index(int id)
        {
            string value = Request.Form["Weeks"].ToString();

            return View();
        }
    }
}