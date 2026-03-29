using System.Configuration;
using Hotel_Manager.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Manager
{
    public class LoginContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
         optionsBuilder.UseSqlServer(
            ConfigurationManager.ConnectionStrings["Hotel_Manager.Properties.Settings.loginConnectionString"].ConnectionString
        );

        public virtual DbSet<FrontendEntity> Frontends { get; set; }
        public virtual DbSet<KitchenEntity> Kitchens { get; set; }

    }
}