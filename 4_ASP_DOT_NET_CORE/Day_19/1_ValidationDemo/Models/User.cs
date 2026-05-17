using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace _1_ValidationDemo.Models {
    public class User {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Range(18, 60, ErrorMessage = "Age must be 18-60")]
        public int Age { get; set; }

        [Remote(action: "IsUsernameAvailable", controller: "User")]
        public string Username { get; set; } = string.Empty;
    }
}