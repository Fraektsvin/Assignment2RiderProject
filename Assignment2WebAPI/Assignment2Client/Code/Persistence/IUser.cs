using System.Threading.Tasks;
using Models;

namespace AdvancedTodoWithWebClientAndLogin.Data
{
    public interface IUserService
    {
        Task<User> ValidateLogin(string username, string password);
    }
}