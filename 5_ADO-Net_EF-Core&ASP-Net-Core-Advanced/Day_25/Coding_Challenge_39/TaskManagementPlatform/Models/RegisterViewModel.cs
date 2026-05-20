using System.ComponentModel.DataAnnotations;

namespace TaskManagementPlatform.Models {
    public class RegisterViewModel {
        [Required] public string? FirstName { get; set; }
        [Required] public string? Username { get; set; }
        [Required][DataType(DataType.Password)] public string? Password { get; set; }
        [Compare("Password")] public string? ConfirmPassword { get; set; }
    }
}