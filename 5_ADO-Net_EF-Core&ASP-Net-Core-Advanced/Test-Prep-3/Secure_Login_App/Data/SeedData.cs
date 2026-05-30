using Microsoft.AspNetCore.Identity;
using Secure_Login_App.Models;

namespace Secure_Login_App.Data {
    public static class SeedData {
        public static async Task Initialize(IServiceProvider serviceProvider) {
            var userManager = serviceProvider.GetRequiredService<UserManager<Application_User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Create roles (Admin and User)
            string[] roleNames = { "Admin", "User" };
            foreach (var roleName in roleNames) {
                if (!await roleManager.RoleExistsAsync(roleName)) {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Create Admin user (as per PDF sample input)
            var adminUser = await userManager.FindByNameAsync("admin");
            if (adminUser == null) {
                adminUser = new Application_User
                {
                    UserName = "admin",
                    Email = "admin@example.com",
                    First_Name = "Rishabh",
                    Last_Name = "Srivastava",
                    Created_At = DateTime.UtcNow
                };
                var result = await userManager.CreateAsync(adminUser, "Admin@123");
                if (result.Succeeded) {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Create User1 (as per PDF sample input)
            var user1 = await userManager.FindByNameAsync("user1");
            if (user1 == null) {
                user1 = new Application_User
                {
                    UserName = "user1",
                    Email = "user1@example.com",
                    First_Name = "Rishu",
                    Last_Name = "Srivastava",
                    Created_At = DateTime.UtcNow
                };
                var result = await userManager.CreateAsync(user1, "User@123");
                if (result.Succeeded) {
                    await userManager.AddToRoleAsync(user1, "User");
                }
            }
        }
    }
}