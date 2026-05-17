using System.ComponentModel.DataAnnotations;

namespace _1_ValidationDemo.Models {
    public class CustomAgeValidation : ValidationAttribute {
        protected override ValidationResult? IsValid(object? value, ValidationContext context) {
            int age = (int)(value ?? 0);
            if (age < 21)
                return new ValidationResult("Age must be above 21 for Indian users");
            return ValidationResult.Success;
        }
    }
}