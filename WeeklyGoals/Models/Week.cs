using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Diagnostics;

namespace WeeklyGoals.Models
{
    [DebuggerDisplay("Id:{Id}, Start:{Start}, End:{End}")]
    public class Week
    {
        public int Id { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        public IEnumerable<Progress> Progress { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
