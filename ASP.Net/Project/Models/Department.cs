using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        [Phone]
        public string PhoneNo { get; set; }
        [Required]
        public string Manager { get; set; }

        public virtual ICollection<Student> Students { get; set; }

    }
}
