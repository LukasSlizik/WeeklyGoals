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
using System.Collections.Generic;

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

        // POST: Goals/Create
        [HttpPost]
        public IActionResult Create([FromBody]Goal goal)
        {
            if (ModelState.IsValid)
            {
                _ctx.Goals.Add(goal);
                _ctx.SaveChanges();
                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetProgressForWeek(string year, string week)
        {
            var yearAsInt = Int32.Parse(year);
            var weekAsInt = Int32.Parse(week);

            var viewModels = new List<ProgressViewModel>();
            var progress = _ctx.Progress.Include(p => p.Goal).Where(p => p.Year == yearAsInt && p.Week == weekAsInt).ToList();

            if (progress == null || !progress.Any())
            {
                CreateProgressForWeek(yearAsInt, weekAsInt);
                progress = _ctx.Progress.Include(p => p.Goal)
                .Where(p => p.Year == yearAsInt && p.Week == weekAsInt).ToList();
            }

            viewModels = progress.Select(p => new ProgressViewModel()
            {
                Id = p.Id,
                Description = p.Goal.Description,
                GoalName = p.Goal.Name,
                Points = p.Points,
                StepSize = p.Goal.StepSize,
                Target = p.Goal.WeeklyTarget,
                Unit = p.Goal.Unit,
                Factor = p.Goal.Factor
            }).ToList();

            return Ok(viewModels);
        }

        private void CreateProgressForWeek(int year, int week)
        {
            var allRelevantGoals = _ctx.Goals.Where(g => g.StartingYear < year || (g.StartingYear == year && g.StartingWeek <= week)).ToList();
            allRelevantGoals.ForEach(g => _ctx.Progress.Add(new Progress(year, week, g)));
            _ctx.SaveChanges();
        }

        [HttpGet]
        public IActionResult UpdateProgress(int progressId, int points)
        {
            var progress = _ctx.Progress.Single(p => p.Id == progressId);
            progress.Points = points;
            _ctx.SaveChanges();

            return Ok();
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
            //var progress = _ctx.Progress.Include(p => p.Goal)
            //                            .Include(p => p.Week)
            //                            .Single(p => p.Id == id);

            //var goalToRemove = progress.Goal;
            //var startingWeek = progress.Week;

            //// select all progress with this goal from this week on.
            //var progressToDelete = _ctx.Progress.Include(p => p.Goal)
            //                                    .Include(p => p.Week)
            //                                    .Where(p => p.Goal.Id == goalToRemove.Id)
            //                                    .Where(p => p.Week.Start >= startingWeek.Start);

            //_ctx.Progress.RemoveRange(progressToDelete);
            //_ctx.SaveChanges();

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