using System.Threading.Tasks;
using JWT.Models;

namespace JWT.Infrastructure.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> CheckLogin(User user, string password);
    }
}
