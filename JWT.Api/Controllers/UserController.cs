using System.Threading.Tasks;
using JWT.Infrastructure.Interfaces;
using JWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Api.Controllers
{
    public class UserController : BaseController<User>
    {
        public UserController(IUserRepository userService) : base(userService)
        {
        }

        [HttpPost]
        [AllowAnonymous]
        public override async Task<IActionResult> Add([FromBody] User entity)
        {
            return await base.Add(entity);
        }

        [HttpDelete]
        [Authorize(Roles = Constants.SuperAdmin)]
        public override async Task<IActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }

        [HttpGet]
        [Authorize(Roles = Constants.Admin)]
        public override async Task<IActionResult> GetAll()
        {
            return await base.GetAll();
        }
    }
}
