using System.Runtime.Serialization;

namespace WeeklyGoals.ViewModels
{
    [DataContract]
    public class ProgressViewModel
    {
        [DataMember(Name = "goalName")]
        public string GoalName { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "stepSize")]
        public int StepSize { get; set; }

        [DataMember(Name = "target")]
        public int Target { get; set; }

        [DataMember(Name = "unit")]
        public string Unit { get; set; }

        [DataMember(Name = "points")]
        public double Points { get; set; }

        [DataMember(Name = "factor")]
        public int Factor { get; set; }
    }
}
