using System.ComponentModel.DataAnnotations;

namespace Project.Validation
{
    public class DateOfBirthValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not DateTime dob)
                return new ValidationResult("Invalid date of birth");
            if (dob >= DateTime.Today)
                return new ValidationResult("Date of birth must be in the past");

            var today = DateTime.Now;
            var calculatedAge = today.Year - dob.Year;
            if (dob.Date > today.AddYears(-calculatedAge)) calculatedAge--;

            var ageProp = validationContext.ObjectInstance.GetType().GetProperty("Age");

            if (ageProp != null)
            {
                var ageVal = (int?)ageProp.GetValue(validationContext.ObjectInstance);
                if (ageVal.HasValue && ageVal.Value != calculatedAge)
                    return new ValidationResult($"Age ({ageVal}) does not match date of birth");
            }
            return ValidationResult.Success;
        }
    }
}
