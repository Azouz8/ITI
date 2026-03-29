using System.Configuration;
using System.Reflection.Metadata;
using Hotel_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Hotel_Manager
{
    public class HotelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
         optionsBuilder.UseSqlServer(
            ConfigurationManager.ConnectionStrings["Hotel_Manager.Properties.Settings.frontend_reservationConnectionString"].ConnectionString
            );

        public virtual DbSet<ReservationEntity> Reservations { get; set; }

    }
}