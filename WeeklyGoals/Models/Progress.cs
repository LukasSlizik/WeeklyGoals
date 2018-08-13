using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace WeeklyGoals.Models
{
    [DebuggerDisplay("Id:{Id}, Year: {Year}, Week:{Week}, Goal:{Goal}, Points:{Points}, ActualPoints:{ActualPoints}")]
    public class Progress
    {
        public int Id { get; set; }
        public Goal Goal { get; set; }

        public int Week { get; set; }
        public int Year { get; set; }

        [Required]
        public double Points { get; set; }

        public Progress() { }

        public Progress(int year, int week, Goal goal) : this()
        {
            Year = year;
            Week = week;
            Goal = goal;
        }

        public Progress(int year, int week, Goal goal, double points) : this(year, week, goal)
        {
            Points = points;
        }

        public double ActualPoints => (Points / Goal.WeeklyTarget) * Goal.Factor;
    }
}
