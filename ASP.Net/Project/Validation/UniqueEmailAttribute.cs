using Project.Data;
using System.ComponentModel.DataAnnotations;

namespace Project.Validation
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var context = (AppDbContext)validationContext.GetService(typeof(AppDbContext));
            var email = value?.ToString();

            var currentId = (int?)validationContext.ObjectInstance.GetType().GetProperty("Id")?.GetValue(validationContext.ObjectInstance) ?? 0;

            var exists = context.Students.Any(s => s.Email == email && s.Id != currentId);

            if (exists)
            {
                return new ValidationResult("This email is already used by another student");
            }
            return ValidationResult.Success;
        }
    }
}
