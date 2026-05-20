using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SecureShoppingApp.Models {
    public class RegisterViewModel {
        [Required, MinLength(3)]
        public string FirstName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(8)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).*$",
            ErrorMessage = "Password must have 1 uppercase, 1 number, 1 special char")]
        public string Password { get; set; } = string.Empty;
    }
}