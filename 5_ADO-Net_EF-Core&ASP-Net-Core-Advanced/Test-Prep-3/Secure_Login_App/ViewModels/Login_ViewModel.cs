using System.ComponentModel.DataAnnotations;

namespace Secure_Login_App.ViewModels {
    public class Login_ViewModel {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool Remember_Me { get; set; }
    }
}