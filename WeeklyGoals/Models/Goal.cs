using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace WeeklyGoals.Models
{
    [DebuggerDisplay("Name:{Name}, Description:{Description}, WeeklyTarget:{WeeklyTarget}, StepSize:{StepSize}, Unit={Unit}, Factor={Factor}")]
    public class Goal
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20,MinimumLength = 2)]
        [DataMember(Name = "name")]
        public string Name { get; set; }
        
        [Required]
        [DataMember(Name = "description")]
        public string Description { get; set; }

        [Required]
        [DataMember(Name = "weeklyTarget")]
        public int WeeklyTarget { get; set;}

        [Required]
        [DataMember(Name = "stepSize")]
        public int StepSize { get; set; }

        [Required]
        [DataMember(Name = "unit")]
        public string Unit { get; set; }

        [Required]
        [DataMember(Name = "factor")]
        public int Factor { get; set; }

        [Required]
        [DataMember(Name = "startingWeek")]
        public string StartingWeek { get; set; }

        public ICollection<Progress> Progress { get; set; }

        public override string ToString() => "Name:{Name}";
    }
}