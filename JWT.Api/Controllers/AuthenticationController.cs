using System.Linq;
using System.Threading.Tasks;
using JWT.Api.Interfaces;
using JWT.Infrastructure.Interfaces;
using JWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Api.Controllers
{
    public class AuthenticationController : ResultController
    {
        private readonly IAuthenticationService _authService;
        private readonly IUserRepository _userRepository;

        public AuthenticationController(IAuthenticationService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("createToken")]
        public async Task<IActionResult> CreateToken(string userName, string password)
        {
            var user = (await _userRepository.GetByQuery(x => x.UserName == userName)).SingleOrDefault();

            if (user != null)
            {
                if (await _userRepository.CheckLogin(user, password))
                {
                    var token = await _authService.GenerateToken(user);

                    return Ok(token);
                }
            }

            return BadRequest("Wrong userName or password");
        }
    }
}
