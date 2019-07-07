using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeeklyGoals.Main.Api.Models;
using WeeklyGoals.Main.Api.Services;

namespace WeeklyGoals.Main.Api.Controllers
{
    [Route("PersonalGoals/Api")]
    public class ActivityController : Controller
    {
        private readonly IActivityRepository _repository;

        public ActivityController(IActivityRepository repository)
        {
            _repository = repository;
        }

        [HttpPost, Route("activities/{activityId}/goals/{goalId}/achievements", Name = "CreateAchievement")]
        public async Task CreateAchievement(Guid activityId, Guid goalId, [FromBody] Achievement body)
        {
            return;
        }

        [HttpPost, Route("activities", Name = "CreateActivity")]
        public async Task CreateActivity([FromBody] Activity body)
        {
            _repository.CreateActivity(body);
        }

        [HttpPost, Route("activities/{activityId}/goals", Name = "CreateGoal")]
        public async Task CreateGoal(Guid activityId, [FromBody] Goal body)
        {
            return;
        }

        [HttpDelete, Route("activities/{activityId}/goals/{goalId}/achievments/{achievmentId}", Name = "DeleteAchievementById")]
        public async Task DeleteAchievementById(Guid activityId, Guid goalId, Guid achievementId)
        {
            return;
        }

        [HttpDelete, Route("activities/{activityId}", Name = "DeleteActivity")]
        public async Task DeleteActivity(Guid activityId)
        {
            return;
        }

        [HttpDelete, Route("activities/{activityId}/goals/{goalId}", Name = "DeleteGoalById")]
        public async Task DeleteGoalById(Guid activityId, Guid goalId)
        {
            return;
        }

        [HttpGet, Route("activities/{activityId}/goals/{goalId}/achievments/{achievmentId}", Name = "GetAchievementById")]
        public async Task<Achievement> GetAchievementById(Guid activityId, Guid goalId, Guid achievementId)
        {
            return new Achievement();
        }

        [HttpGet, Route("activities", Name = "GetActivities")]
        public async Task<ICollection<Activity>> GetActivities()
        {
            return _repository.GetActivities();
        }

        [HttpGet, Route("activities/{activityId}", Name = "GetActivityById")]
        public async Task<Activity> GetActivityById(Guid activityId)
        {
            return new Activity();
        }

        [HttpGet, Route("activities/{activityId}/goals/{goalId}/achievements", Name = "GetAllAchievementsForGoal")]
        public async Task<ICollection<Achievement>> GetAllAchievementsForGoal(Guid activityId, Guid goalId)
        {
            return new Collection<Achievement>();
        }

        [HttpGet, Route("activities/{activityId}/goals/{goalId}", Name = "GetGoalById")]
        public async Task<Goal> GetGoalById(Guid activityId, Guid goalId)
        {
            return new Goal();
        }

        [HttpGet, Route("activities/{activityId}/goals", Name = "GetGoalsForActivity")]
        public async Task<ICollection<Goal>> GetGoalsForActivity(Guid activityId)
        {
            return new Collection<Goal>();
        }

        [HttpPut, Route("activities/{activityId}/goals/{goalId}/achievments/{achievmentId}", Name = "UpdateAchievement")]
        public async Task UpdateAchievement(Guid activityId, Guid goalId, Guid achievementId, [FromBody] Achievement body)
        {
            return;
        }

        [HttpPut, Route("activities/{activityId}", Name = "UpdateActivity")]
        public async Task UpdateActivity(Guid activityId, [FromBody] Activity body)
        {
            return;
        }

        [HttpPut, Route("activities/{activityId}/goals/{goalId}", Name = "UpdateGoal")]
        public async Task UpdateGoal(Guid activityId, Guid goalId, [FromBody] Goal body)
        {
            return;
        }
    }
}