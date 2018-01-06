using Microsoft.AspNetCore.Mvc;
using WeeklyGoals.Models;
using WeeklyGoals.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace WeeklyGoals.Controllers
{
    public class HomeController : Controller
    {
        private GoalsContext _ctx;

        public HomeController(GoalsContext ctx)
        {
            _ctx = ctx;
        }

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

        [HttpGet]
        public IActionResult AjaxRequest()
        {
            return Ok("hello world");
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

            var runningTotal = selectedWeek.Progress.Sum(p => p.Points);
            var total = selectedWeek.Progress.Sum(p => p.Goal.WeeklyTarget);

            if (selectedWeek == null)
                return null;

            var vm = new MainViewModel(new SelectList(weeks), selectedWeek, selectedWeek.Progress.OrderBy(p => p.Id).ToList());
            vm.RunningTotal = runningTotal;
            vm.Total = total;
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
            return Ok(progress.Points);
        }


        //[HttpGet]
        //public IActionResult UpdateProgress(int? id, int multiplicator, string selectedWeek)
        //{
        //    if (id == null)
        //        return NotFound();

        //    var progress = _ctx.Progress.Include(p => p.Goal).Single(p => p.Id.Equals(id));
        //    if (progress == null)
        //        return NotFound();

        //    var goal = _ctx.Goals.Single(g => g.Id.Equals(progress.Goal.Id));
        //    if (goal == null)
        //        return NotFound();

        //    var delta = goal.StepSize * multiplicator;
        //    progress.Points += delta;

        //    var gPoints = (progress.Points / progress.Goal.WeeklyTarget) * 100;
        //    _ctx.SaveChanges();

        //    var vm = GetViewModel(selectedWeek);
        //    return View("Index", vm);
        //}

    }
}