using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeeklyGoals.Models
{
    internal interface IGoalsRepository
    {
        IEnumerable<Goal> GetAllGoals();
        Goal GetGoalById(int id);

        IEnumerable<Progress> GetAllProgress();
        Progress GetProgressById(int id);

        IEnumerable<Week> GetAllWeeks();
        Week GetWeekById(int id);
    }

    internal class GoalsRepository : IGoalsRepository
    {
        public IEnumerable<Goal> GetAllGoals()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Progress> GetAllProgress()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Week> GetAllWeeks()
        {
            throw new NotImplementedException();
        }

        public Goal GetGoalById(int id)
        {
            throw new NotImplementedException();
        }

        public Progress GetProgressById(int id)
        {
            throw new NotImplementedException();
        }

        public Week GetWeekById(int id)
        {
            throw new NotImplementedException();
        }
    }

}
