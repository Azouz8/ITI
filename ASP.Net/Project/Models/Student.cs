using Project.Validation;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Name must be at least 6 characters")]
        [MaxLength(15, ErrorMessage = "Name must be at most 15 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces")]
        public string Name { get; set; }
        [Range(14, 25, ErrorMessage = "Age must be between 14 and 25")]
        public int Age { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }
        [Required]
        [UniqueEmail]
        [EmailAddress]
        public string Email { get; set; }

        [Range(1, 10)]
        public string Level { get; set; }
        [DateOfBirthValidation]
        public DateTime DateOfBirth { get; set; }

        public string? ImagePath { get; set; }

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
