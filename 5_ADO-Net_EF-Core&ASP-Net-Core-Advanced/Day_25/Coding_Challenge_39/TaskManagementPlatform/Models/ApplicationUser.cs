using Microsoft.AspNetCore.Identity;

namespace TaskManagementPlatform.Models {
    public class ApplicationUser : IdentityUser {
        public string? FirstName { get; set; }
    }
}