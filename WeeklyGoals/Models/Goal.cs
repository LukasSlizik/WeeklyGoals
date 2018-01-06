using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeeklyGoals.Models
{
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

        public IEnumerable<Progress> Progress { get; set; }
    }
}