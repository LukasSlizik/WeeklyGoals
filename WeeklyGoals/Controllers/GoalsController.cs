using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WeeklyGoals.Models;

namespace WeeklyGoals.Controllers
{
    //[Authorize]
    //public class GoalsController : Controller
    //{
    //    private readonly GoalsContext _ctx;

    //    public GoalsController(GoalsContext ctx)
    //    {
    //        _ctx = ctx;
    //    }

    //    // GET: Goals
    //    public async Task<IActionResult> Index()
    //    {
    //        return View(await _ctx.Goals.ToListAsync());
    //    }


    //}
}
