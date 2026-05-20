using System.ComponentModel.DataAnnotations;

namespace SecureShoppingApp.Models {
    public class User {
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string FirstName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Role { get; set; } = "Customer"; // Admin or Customer
    }
}