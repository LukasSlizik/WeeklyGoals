using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WeeklyGoals.Models;

namespace WeeklyGoals.Controllers
{
    public class WeeksController : Controller
    {
        private GoalsContext _ctx;

        public WeeksController(GoalsContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IActionResult> Index()
        {
            var weeks = await _ctx.Weeks.ToListAsync();
            return View(weeks);
        }
    }
}