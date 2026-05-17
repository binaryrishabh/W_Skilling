using Microsoft.EntityFrameworkCore;
using _1_StudentManagementSystem.Models;

namespace _1_StudentManagementSystem.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}