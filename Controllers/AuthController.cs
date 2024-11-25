using Microsoft.AspNetCore.Mvc;
using DevConnectorBackend.Data;
using DevConnectorBackend.Models;
using DevConnectorBackend.Services;
using BCrypt.Net;

namespace DevConnectorBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;

        public AuthController(AppDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Role = "User";
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("Registration successful");
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
                return Unauthorized("Invalid credentials");

            var token = _tokenService.GenerateToken(user.Email, user.Role);
            return Ok(new { token });
        }
    }
}
