namespace WeeklyGoals.ViewModels
{
    public class ProgressViewModel
    {
        public string GoalName { get; set; }
        public string Description { get; set; }
        public int StepSize { get; set; }
        public int Target { get; set; }
        public string Unit { get; set; }
        public int Progress { get; set; }
        public double Points { get; set; }
    }
}
