using Microsoft.AspNetCore.Identity;

namespace Project.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

        public int? StudentId { get; set; }
        public virtual Student? Student { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}