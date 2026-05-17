using System.ComponentModel.DataAnnotations;

namespace _1_ValidationDemo.Models {
    public class Student : IValidatableObject {
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext context) {
        if (Name == "Rahul" && Age < 25)
            yield return new ValidationResult("Rahul must be above 25");
    }
}
}