using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>()
                .HasIndex(d => d.Name)
                .IsUnique();

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Students)
                .WithOne(s => s.Department)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Student)
                .WithOne()
                .HasForeignKey<ApplicationUser>(u => u.StudentId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}