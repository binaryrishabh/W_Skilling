using SecureShoppingApp.Data;
using SecureShoppingApp.Models;
using System.Security.Cryptography;
using System.Text;

namespace SecureShoppingApp.Services {
    public class AuthService {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context) {
            _context = context;
        }

        // Simple hash (use BCrypt in production)
        private string HashPassword(string password) {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        public bool Register(RegisterViewModel model) {
            if (_context.Users.Any(u => u.Email == model.Email))
                return false;

            var user = new User
            {
                FirstName = model.FirstName,
                Email = model.Email,
                PasswordHash = HashPassword(model.Password),
                Role = "Customer"
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public User? Login(string email, string password) {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null) return null;

            var hashed = HashPassword(password);
            return user.PasswordHash == hashed ? user : null;
        }
    }
}