using System.Collections.Generic;
using WeeklyGoals.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WeeklyGoals.ViewModels
{
    public class MainViewModel
    {
        public SelectList Weeks { get; set; }
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
