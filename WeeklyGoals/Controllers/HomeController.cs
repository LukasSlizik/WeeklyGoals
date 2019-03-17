using Microsoft.AspNetCore.Mvc;
using WeeklyGoals.Models;
using WeeklyGoals.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Index()
        {
            return Ok("Hello from Index");
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("userdata")]
        public IActionResult UserData()
        {
            return Ok("userdata");
        }

        // returns all progress records for the specified week
        private IEnumerable<Progress> GetAllProgressForWeek(int year, int week)
        {
            return _ctx.Progress.Include(p => p.Goal).Where(p => p.Year == year && p.Week == week);
        }

        // returns all goals for the specified week
        private IEnumerable<Goal> GetAllGoalsForWeek(int year, int week)
        {
            return _ctx.Goals.Where(g => g.StartingYear < year || (g.StartingYear == year && g.StartingWeek <= week));
        }

        // converts the list of progress entities to list of progress ViewModels
        private IEnumerable<ProgressViewModel> MapToProgressViewModels(IEnumerable<Progress> allProgress)
        {
            var viewModels = new List<ProgressViewModel>();
            viewModels = allProgress.Select(p => new ProgressViewModel()
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

            return viewModels;
        }

        /// <summary>
        /// Returns all goals.
        /// </summary>
        [HttpGet]
        public IActionResult GetAllGoals()
        {
            return Ok(_ctx.Goals);
        }

        /// <summary>
        /// Returns all progress records for the specified week. Missing goals will be automatically inserted to the db.
        /// </summary>
        [HttpGet]
        [Route("GetProgressForWeek")]
        public IActionResult GetProgressForWeek(string year, string week)
        {
            var yearAsInt = Int32.Parse(year);
            var weekAsInt = Int32.Parse(week);

            // get records from the db
            var allProgressForWeek = GetAllProgressForWeek(yearAsInt, weekAsInt).ToList();
            var allGoalsForWeek = GetAllGoalsForWeek(yearAsInt, weekAsInt).ToList();

            // get all goals that are not yet in the progress for the actual week
            var missingGoals = allGoalsForWeek.Except(allProgressForWeek.Select(p => p.Goal)).ToList();
            missingGoals.ForEach(goal => _ctx.Progress.Add(new Progress(yearAsInt, weekAsInt, goal)));

            // save all the missing goals in the actul progress and load the progress once again
            _ctx.SaveChanges();
            allProgressForWeek = GetAllProgressForWeek(yearAsInt, weekAsInt).ToList();

            return Ok(MapToProgressViewModels(allProgressForWeek));
        }

        [HttpGet]
        public IActionResult UpdateProgress(int progressId, int points)
        {
            var progress = _ctx.Progress.Single(p => p.Id == progressId);
            progress.Points = points;
            _ctx.SaveChanges();

            return Ok();
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