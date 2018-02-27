using Microsoft.AspNetCore.Mvc;
using WeeklyGoals.Models;
using WeeklyGoals.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using Microsoft.AspNetCore.Authorization;

namespace WeeklyGoals.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private GoalsContext _ctx;

        public HomeController(GoalsContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(GetViewModel("1"));
        }

        [HttpPost]
        public IActionResult Select(string SelectedWeek)
        {
            var vm = GetViewModel(SelectedWeek);
            if (vm == null)
                return NotFound();

            return View("Index", vm);
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
        public IActionResult UpdateProgress(int? id, int multiplicator)
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

    }
}