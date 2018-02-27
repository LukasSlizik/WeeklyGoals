using System.ComponentModel.DataAnnotations;

namespace WeeklyGoals.Models
{
    public class Progress
    {
        public int Id { get; set; }
        public Week Week { get; set; }
        public Goal Goal { get; set; }

        [Required]
        public double Points { get; set; }

        public Progress() { }

        public Progress(Week week, Goal goal) : this()
        {
            Week = week;
            Goal = goal;
        }

        public Progress(Week week, Goal goal, double points) : this(week, goal)
        {
            Points = points;
        }

        public double ActualPoints => (Points / Goal.WeeklyTarget) * Goal.Factor;
    }
}
