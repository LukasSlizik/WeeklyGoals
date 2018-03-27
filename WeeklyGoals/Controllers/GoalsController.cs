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

    //    // GET: Goals/Details/5
    //    public async Task<IActionResult> Details(int? id)
    //    {
    //        if (id == null)
    //            return NotFound();

    //        var goal = await _ctx.Goals.SingleOrDefaultAsync(m => m.Id == id);
    //        if (goal == null)
    //            return NotFound();

    //        return View(goal);
    //    }

    //    // GET: Goals/Create
    //    [HttpGet]
    //    public IActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: Goals/Create
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create([Bind("Name, Description, WeeklyTarget, StepSize, Unit")] Goal goal)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            var entity = _ctx.Add(goal);
    //            await _ctx.SaveChangesAsync();

    //            foreach (var week in _ctx.Weeks)
    //            {
    //                var p = new Progress(week, goal);
    //                _ctx.Add(p);
    //            }

    //            await _ctx.SaveChangesAsync();

    //            return RedirectToAction(nameof(Index), "Home");
    //        }
    //        return View(nameof(Index), "Home");
    //    }

    //    // GET: Goals/Edit/5
    //    public async Task<IActionResult> Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var goal = await _ctx.Goals.SingleOrDefaultAsync(m => m.Id == id);
    //        if (goal == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(goal);
    //    }

        //// POST: Goals/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Progress,StepSize,Points,MaxPoints")] Goal goal)
        //{
        //    if (id != goal.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _ctx.Update(goal);
        //            await _ctx.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!GoalExists(goal.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(goal);
        //}
    //}
}
