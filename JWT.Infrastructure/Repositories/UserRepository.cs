using System.Threading.Tasks;
using JWT.Infrastructure.Data;
using JWT.Infrastructure.Helpers;
using JWT.Infrastructure.Interfaces;
using JWT.Models;

namespace JWT.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public async Task<bool> CheckLogin(User user, string password)
        {
            var result = PasswordHelper.Verify(password, user.PasswordHash);

            return result;
        }
    }
}
