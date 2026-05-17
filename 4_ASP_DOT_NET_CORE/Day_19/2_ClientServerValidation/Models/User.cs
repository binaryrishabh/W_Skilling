using System.ComponentModel.DataAnnotations;

namespace _2_ClientServerValidation.Models {
    public class User {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Name must be 2-20 characters")]
        public string Name { get; set; }
    }
}