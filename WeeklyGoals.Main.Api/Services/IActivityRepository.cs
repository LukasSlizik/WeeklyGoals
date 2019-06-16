using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeeklyGoals.Main.Api.Models;

namespace WeeklyGoals.Main.Api.Services
{
    public interface IActivityRepository
    {
        ICollection<Activity> GetActivities();
    }
}
