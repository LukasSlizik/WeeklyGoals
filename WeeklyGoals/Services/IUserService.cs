using System.Threading.Tasks;
using WeeklyGoals.Models;

namespace WeeklyGoals.Services
{
    public interface IUserService
    {
        Task<User> AuthenticateExternalUser(string externalId);
        Task<User> RegisterExternalUser(string externalId, string username, string email);
    }
}
