using Lessons_api.Domain.Interfaces;
using Lessons_api.Domain.UserModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lessons_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var user = await _userService.GetUserById(id);

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] BaseUserDTO model)
        {
            var addedUser = await _userService.AddUser(model);

            return Ok(addedUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] BaseUserDTO model)
        {
            var updatedUser = await _userService.UpdateUser(id, model);

            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            await _userService.DeleteUserById(id);

            return Ok();
        }
    }
}
