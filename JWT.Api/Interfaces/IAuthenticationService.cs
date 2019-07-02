using System.Threading.Tasks;
using JWT.Models;

namespace JWT.Api.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> GenerateToken(User user);
    }
}
