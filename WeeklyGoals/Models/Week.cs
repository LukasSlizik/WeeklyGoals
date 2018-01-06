using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WeeklyGoals.Models
{
    public class Week
    {
        public int Id { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        public IEnumerable<Progress> Progress { get; set; }

        //public override string ToString()
        //{
        //    var format = "dd.MM.yyyy";
        //    var startDate = Start.ToString(format);
        //    var endDate = End.ToString(format);

        //    return $"{startDate} - {endDate}";
        //}

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
