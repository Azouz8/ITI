using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Level { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
