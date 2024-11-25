using Microsoft.AspNetCore.Mvc;
using DevConnector.Services;
using DevConnector.Models;

namespace DevConnector.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = Role.Admin)]  // Restrict to admin
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        public ActionResult CreateUser([FromBody] User user)
        {
            _adminService.CreateUser(user);
            return CreatedAtAction(nameof(CreateUser), new { id = user.Id }, user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _adminService.DeleteUser(id);
            return NoContent();
        }
    }
}
