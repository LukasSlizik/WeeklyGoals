using System.Collections.Generic;
using WeeklyGoals.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WeeklyGoals.ViewModels
{
    public class MainViewModel
    {
        public SelectList Weeks { get; set; }

        [Display(Name = "Selected Week")]
        public Week SelectedWeek { get; set; }
        public IEnumerable<Progress> Progress { get; set; }
        public double RunningTotal { get; set; }
        public double Total { get; set; }

        public MainViewModel() { }

        public MainViewModel(SelectList weeks, Week selectedWeek, IEnumerable<Progress> progress)
        {
            Weeks = weeks;
            SelectedWeek = selectedWeek;
            Progress = progress;
        }
    }
}
