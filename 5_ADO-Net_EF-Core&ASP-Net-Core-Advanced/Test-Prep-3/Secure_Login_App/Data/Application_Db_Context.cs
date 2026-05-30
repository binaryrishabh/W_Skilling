using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Secure_Login_App.Models;

namespace Secure_Login_App.Data {
    public class Application_Db_Context : IdentityDbContext<Application_User> {
        public Application_Db_Context(DbContextOptions<Application_Db_Context> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
        }
    }
}