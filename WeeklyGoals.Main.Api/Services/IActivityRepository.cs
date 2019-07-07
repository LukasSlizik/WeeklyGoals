using System.Collections.Generic;
using WeeklyGoals.Main.Api.Models;

namespace WeeklyGoals.Main.Api.Services
{
    public interface IActivityRepository
    {
        void CreateActivity(Activity activity);
        ICollection<Activity> GetActivities();
    }
}
