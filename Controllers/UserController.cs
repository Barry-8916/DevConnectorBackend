using Microsoft.AspNetCore.Mvc;
using DevConnector.Services;
using DevConnector.Models;

namespace DevConnector.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            _userService.UpdateUser(user);
            return NoContent();
        }
    }
}
