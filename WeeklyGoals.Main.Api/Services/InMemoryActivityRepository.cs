using System;
using System.Collections.Generic;
using WeeklyGoals.Main.Api.Models;

namespace WeeklyGoals.Main.Api.Services
{
    public class InMemoryActivityRepository : IActivityRepository
    {
        private ICollection<Activity> _activities;

        public InMemoryActivityRepository()
        {
            Initialize();
        }

        private void Initialize()
        {
            _activities = new List<Activity>()
            {
                new Activity() {Description = "Hello World !", Id = Guid.NewGuid(), Name = "Activity1!"},
                new Activity() {Description = "Hello Sun !", Id = Guid.NewGuid(), Name = "Activity2!"}
            };
        }

        public ICollection<Activity> GetActivities()
        {
            return _activities;
        }
    }
}
