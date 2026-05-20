using Microsoft.EntityFrameworkCore;
using SecureShoppingApp.Models;
using System.Security.Cryptography;
using System.Text;

namespace SecureShoppingApp.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        // Helper method to generate same hash as AuthService
        private string HashPassword(string password) {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Seed admin user with correct hash
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FirstName = "Admin",
                Email = "admin@shop.com",
                PasswordHash = HashPassword("Admin@123"),  // Fixed hash
                Role = "Admin"
            });

            // Seed products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 50000, Description = "Gaming laptop" },
                new Product { Id = 2, Name = "Mouse", Price = 500, Description = "Wireless mouse" }
            );
        }
    }
}