using System.Threading.Tasks;
using WeeklyGoals.Models;

namespace WeeklyGoals.Services
{
    public interface IUserService
    {
        Task<User> Add(string name, string email, string password);
        Task<User> AuthenticateExternal(string id);
        Task<User> AddExternal(string id, string name, string email);
    }
}
