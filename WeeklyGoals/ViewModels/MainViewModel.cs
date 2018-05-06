using System.Collections.Generic;
using WeeklyGoals.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WeeklyGoals.ViewModels
{
    public class MainViewModel
    {
        public SelectList Weeks { get; set; }
        [Display(Name = "Selected Week")]
        public Week SelectedWeek { get; set; }
        public IEnumerable<Progress> Progress => SelectedWeek.Progress.OrderBy(p => p.Id);
        public int RunningTotal => SelectedWeek.Progress.Sum(p => (int)(p.Points / p.Goal.WeeklyTarget) * p.Goal.Factor);
        public int Total => SelectedWeek.Progress.Sum(p => p.Goal.Factor);
        public int OverallPercentage => (int)(((double)RunningTotal / Total) * 100);

        public MainViewModel() { }

        public MainViewModel(SelectList weeks, Week selectedWeek)
        {
            Weeks = weeks;
            SelectedWeek = selectedWeek;
        }
    }
}
