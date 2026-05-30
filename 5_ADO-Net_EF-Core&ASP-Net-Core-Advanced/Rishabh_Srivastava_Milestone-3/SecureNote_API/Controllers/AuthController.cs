using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureNote_API.Data;
using SecureNote_API.Models;
using SecureNote_API.Services;

namespace SecureNote_API.Controllers {
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase {
        private readonly AppDbContext _context;
        private readonly JwtService _jwt;

        public AuthController(AppDbContext context, JwtService jwt) {
            _context = context;
            _jwt = jwt;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AuthRequest req) {
            if (await _context.Users.AnyAsync(u => u.Username == req.Username))
                return BadRequest(new { message = "Username already exists" });

            if (req.Username.Length < 3 || req.Password.Length < 8)
                return BadRequest(new { message = "Username min 3 chars, Password min 8 chars" });

            var user = new User
            {
                Username = req.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(new { message = "User registered successfully. Please log in." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthRequest req) {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == req.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(req.Password, user.PasswordHash))
                return Unauthorized(new { message = "Invalid credentials" });

            var token = _jwt.GenerateToken(user.Username, user.Id);
            return Ok(new { token, expires_in = 3600, user = new { username = user.Username } });
        }
    }
}