using Microsoft.AspNetCore.Mvc;
using WeeklyGoals.Models;
using WeeklyGoals.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text.RegularExpressions;

namespace WeeklyGoals.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private GoalsContext _ctx;
        private Regex _weekRegex = new Regex("^[0-9]{4}-W([0-9]{2})$");
        private Regex _yearRegex = new Regex("^([0-9]{4})-W[0-9]{2}$");

        public HomeController(GoalsContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult Login()
        {
            // challenge the user by logging in with OIDC server 
            return Challenge(new AuthenticationProperties { RedirectUri = Url.Action(nameof(Index)) }, OpenIdConnectDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            // remove cookie that authenticates user
            // also logout of OIDC identity provider
            return SignOut(new AuthenticationProperties { RedirectUri = Url.Action(nameof(Index)) }, CookieAuthenticationDefaults.AuthenticationScheme, OpenIdConnectDefaults.AuthenticationScheme);
        }

        // GET: Goals/Create/2
        [HttpGet]
        public IActionResult Create(int? selectedWeekId)
        {
            if (selectedWeekId == null)
                return NotFound();

            TempData["weekId"] = selectedWeekId.Value;
            return View();
        }

        // POST: Goals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name, Description, WeeklyTarget, StepSize, Unit")]Goal goal)
        {
            if (ModelState.IsValid)
            {
                // get and check the selected Week
                var weekId = (int)TempData["weekId"];
                var selectedWeek = _ctx.Weeks.SingleOrDefault(w => w.Id == weekId);
                if (selectedWeek == null)
                    return NotFound();

                var entity = _ctx.Add(goal);

                // add new progress from the selected Week on
                foreach (var week in _ctx.Weeks.Where(w => w.Start >= selectedWeek.Start).ToList())
                {
                    var progress = new Progress(week, goal);
                    _ctx.Add(progress);
                }
                _ctx.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Index));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(GetViewModel("1"));
        }

        [HttpPost]
        public IActionResult SelectWeek(DateTime o)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Select(string week)
        {
            var parsedYear = ParseYear(week);
            var parsedWeek = ParseWeek(week);

            var vm = GetViewModel(parsedWeek);
            if (vm == null)
                return NotFound();

            return View("Index", vm);
        }

        private string ParseWeek(string week)
        {
            var parsedWeek = _weekRegex.Match(week);
            return parsedWeek.Groups.Skip(1).First().Value;
        }

        private string ParseYear(string week)
        {
            var parsedYear = _yearRegex.Match(week);
            return parsedYear.Groups.Skip(1).First().Value;
        }

        private MainViewModel GetViewModel(string SelectedWeek)
        {
            if (!int.TryParse(SelectedWeek, out int id))
                return null;

            var weeks = _ctx.Weeks.Include(w => w.Progress)
                                  .ThenInclude(p => p.Goal)
                                  .ToList();

            var selectedWeek = weeks.SingleOrDefault(w => w.Id.Equals(id));
            selectedWeek.Progress = selectedWeek.Progress.OrderBy(p => p.Id).ToList();

            if (selectedWeek == null)
                return null;

            var vm = new MainViewModel(new SelectList(weeks), selectedWeek);
            return vm;
        }

        [HttpGet]
        public IActionResult UpdateProgress1(int? id, int multiplicator)
        {
            if (id == null)
                return NotFound();

            var progress = _ctx.Progress.Include(p => p.Goal).Single(p => p.Id.Equals(id));
            if (progress == null)
                return NotFound();

            var goal = _ctx.Goals.Single(g => g.Id.Equals(progress.Goal.Id));
            if (goal == null)
                return NotFound();

            var delta = goal.StepSize * multiplicator;
            progress.Points += delta;

            var total = (progress.Points / progress.Goal.WeeklyTarget) * progress.Goal.Factor;

            _ctx.SaveChanges();
            return Ok(new { points = progress.Points, unit = progress.Goal.Unit, total = total });
        }

        // GET: /Home/Delete/1
        [HttpGet]
        public IActionResult Delete(int? progressId)
        {
            if (progressId == null)
                return NotFound();

            var progress = _ctx.Progress.Include(p => p.Goal)
                                        .Include(p => p.Week)
                                        .SingleOrDefault(p => p.Id == progressId);
            if (progress == null)
                return NotFound();

            return View(progress);
        }

        // POST: Home/Delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var progress = _ctx.Progress.Include(p => p.Goal)
                                        .Include(p => p.Week)
                                        .Single(p => p.Id == id);

            var goalToRemove = progress.Goal;
            var startingWeek = progress.Week;

            // select all progress with this goal from this week on.
            var progressToDelete = _ctx.Progress.Include(p => p.Goal)
                                                .Include(p => p.Week)
                                                .Where(p => p.Goal.Id == goalToRemove.Id)
                                                .Where(p => p.Week.Start >= startingWeek.Start);

            _ctx.Progress.RemoveRange(progressToDelete);
            _ctx.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: Goals/Details/5
        public IActionResult Details(int? goalId)
        {
            if (goalId == null)
                return NotFound();

            var goal = _ctx.Goals.SingleOrDefault(m => m.Id == goalId);
            if (goal == null)
                return NotFound();

            return View(goal);
        }

        // GET: Goals/Edit/5
        public IActionResult Edit(int? goalId)
        {
            if (goalId == null)
                return NotFound();

            var goal = _ctx.Goals.SingleOrDefault(m => m.Id == goalId);
            if (goal == null)
                return NotFound();

            return View(goal);
        }

        // POST: Goals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description,WeeklyTarget,StepSize,Unit,Factor")] Goal goal)
        {
            if (id != goal.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _ctx.Update(goal);
                    _ctx.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_ctx.Goals.Any(g => g.Id == goal.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(goal);
        }

        // POST: Home/DeletePermanent/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePermanent(int id)
        {
            // get the Id of the goal to delete
            var goalId = _ctx.Progress.Include(p => p.Goal)
                                      .Where(p => p.Id == id)
                                      .Select(p => p.Goal.Id)
                                      .Single();
            var goalToDelete = _ctx.Goals.Single(g => g.Id == goalId);

            // remove this goal permanently with cascading delete (with all Progress)
            _ctx.Goals.Remove(goalToDelete);
            _ctx.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}