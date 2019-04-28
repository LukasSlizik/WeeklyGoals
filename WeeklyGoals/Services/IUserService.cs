using System.Threading.Tasks;

namespace WeeklyGoals.Services
{
    public interface IUserService
    {
        Task<User> Add(string name, string email, string password);
        Task<User> AuthenticateExternal(string id);
        Task<User> AddExternal(string id, string name, string email);
    }
}
