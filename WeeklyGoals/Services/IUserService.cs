using System.Threading.Tasks;
using WeeklyGoals.Models;
using WeeklyGoals.Models.Auth;

namespace WeeklyGoals.Services
{
    public interface IUserService
    {
        Task<bool> IsExternalUserRegistered(string externalId);
        Task<User> RegisterExternalUser(string externalId, string username, string email);
    }
}
