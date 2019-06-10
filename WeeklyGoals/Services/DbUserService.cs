using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WeeklyGoals.Models;
using WeeklyGoals.Models.Auth;

namespace WeeklyGoals.Services
{
    public class DbUserService : IUserService
    {
        private readonly GoalsContext _goalsContext;


        public DbUserService(GoalsContext goalsContext)
        {
            _goalsContext = goalsContext;
        }

        public async Task<User> RegisterExternalUser(string externalId, string username, string email)
        {
            var user = await _goalsContext.Users.AddAsync(new User(externalId, username, email));
            _goalsContext.SaveChanges();

            return user.Entity;
        }

        public async Task<bool> IsExternalUserRegistered(string externalId)
        {
            var user = await _goalsContext.Users.SingleOrDefaultAsync(u => u.ExternalId == externalId);
            return user != null;
        }
    }
}
