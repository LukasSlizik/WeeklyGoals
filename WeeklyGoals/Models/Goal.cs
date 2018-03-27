using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace WeeklyGoals.Models
{
    [DebuggerDisplay("Name:{Name}, Description:{Description}, WeeklyTarget:{WeeklyTarget}, StepSize:{StepSize}, Unit={Unit}, Factor={Factor}")]
    public class Goal
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20,MinimumLength = 2)]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]
        public int WeeklyTarget { get; set;}

        [Required]
        public int StepSize { get; set; }

        [Required]
        public string Unit { get; set; }

        [Required]
        public int Factor { get; set; }

        public ICollection<Progress> Progress { get; set; }

        public override string ToString() => "Name:{Name}";
    }
}