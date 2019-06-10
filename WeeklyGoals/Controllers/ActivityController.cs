using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeeklyGoals.Models.NewModels;
using WeeklyGoals.Services;

namespace WeeklyGoals.Controllers
{
    [Route("PersonalGoals/Api/v1")]
    public class ActivityController : Controller
    {
        private IActivityRepository _repository;

        public ActivityController(IActivityRepository repository)
        {
            _repository = repository;
        }

        [HttpGet, Route("activities", Name = "GetActivities")]
        public async Task<ICollection<Activity>> GetActivities()
        {
            return new Collection<Activity>();
        }

        [HttpPost, Route("activities", Name = "CreateActivity")]
        public async Task CreateActivity([FromBody] Activity body)
        {
            return;
        }

        [HttpGet, Route("activities/{activityId}", Name = "GetActivityById")]
        public async Task<Activity> GetActivityById(Guid activityId)
        {
            return new Activity();
        }

        [HttpPut, Route("activities/{activityId}", Name = "UpdateActivity")]
        public async Task UpdateActivity(Guid activityId, [FromBody] Activity body)
        {
            return;
        }

        [HttpDelete, Route("activities/{activityId}", Name = "DeleteActivity")]
        public async Task DeleteActivity(Guid activityId)
        {
            return;
        }

        [HttpGet, Route("activities/{activityId}/goals", Name = "GetGoalsForActivity")]
        public async Task<ICollection<Goal>> GetGoalsForActivity(Guid activityId)
        {
            return new Collection<Goal>();
        }

        [HttpPost, Route("activities/{activityId}/goals", Name = "CreateGoal")]
        public async Task CreateGoal(Guid activityId, [FromBody] Goal body)
        {
            return;
        }

        [HttpGet, Route("activities/{activityId}/goals/{goalId}", Name = "GetGoalById")]
        public async Task<Goal> GetGoalById(Guid activityId, Guid goalId)
        {
            return new Goal();
        }

        [HttpPut, Route("activities/{activityId}/goals/{goalId}", Name = "UpdateGoal")]
        public async Task UpdateGoal(Guid activityId, Guid goalId, [FromBody] Goal body)
        {
            return;
        }

        [HttpDelete, Route("activities/{activityId}/goals/{goalId}", Name = "DeleteGoalById")]
        public async Task DeleteGoalById(Guid activityId, Guid goalId)
        {
            return;
        }

        [HttpGet, Route("activities/{activityId}/goals/{goalId}/achievements", Name = "GetAllAchievementsForGoal")]
        public async Task<ICollection<Achievement>> GetAllAchievementsForGoal(Guid activityId, Guid goalId)
        {
            return new Collection<Achievement>();
        }

        [HttpPost, Route("activities/{activityId}/goals/{goalId}/achievements", Name = "CreateAchievement")]
        public async Task CreateAchievement(Guid activityId, Guid goalId, [FromBody] Achievement body)
        {
            return;
        }

        [HttpGet, Route("activities/{activityId}/goals/{goalId}/achievments/{achievmentId}", Name = "GetAchievementById")]
        public async Task<Achievement> GetAchievementById(Guid activityId, Guid goalId, Guid achievementId)
        {
            return new Achievement();
        }

        [HttpPut, Route("activities/{activityId}/goals/{goalId}/achievments/{achievmentId}", Name = "UpdateAchievement")]
        public async Task UpdateAchievement(Guid activityId, Guid goalId, Guid achievementId, [FromBody] Achievement body)
        {
            return;
        }

        [HttpDelete, Route("activities/{activityId}/goals/{goalId}/achievments/{achievmentId}", Name = "DeleteAchievementById")]
        public async Task DeleteAchievementById(Guid activityId, Guid goalId, Guid achievementId)
        {
            return;
        }
    }
}