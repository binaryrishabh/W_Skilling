using System.ComponentModel.DataAnnotations;

namespace _1_StudentManagementSystem.Models {
    public class Student {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course is required")]
        public string Course { get; set; } = string.Empty;

        [Range(18, 60)]
        public int Age { get; set; }
    }
}