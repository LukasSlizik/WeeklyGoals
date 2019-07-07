using System.Collections.Generic;
using System.Linq;
using WeeklyGoals.Main.Api.Models;

namespace WeeklyGoals.Main.Api.Services
{
    public class DbActivityRepository : IActivityRepository
    {
        private readonly ActivitiesContext _dbCtx;

        public DbActivityRepository(ActivitiesContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public ICollection<Activity> GetActivities()
        {
            return _dbCtx.Activities.ToList();
        }

        public void CreateActivity(Activity activity)
        {
            _dbCtx.Activities.Add(activity);
            _dbCtx.SaveChanges();
        }
    }
}
