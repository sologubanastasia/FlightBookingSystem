using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FlightApp.Domain.Entities;

namespace FlightApp.Infrastructure
{

    public class FlightDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options)
        {
            
        }

        public DbSet<Booking> Bookings { get; set; } 
        public DbSet<BookingSeat> BookingSeats { get; set; } = null!;
        public DbSet<Flight> Flights { get; set; } 
        public DbSet<Seat> Seats { get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BookingSeat>()
              .HasKey(bs => new { bs.BookingId, bs.SeatId });

            builder.ApplyConfigurationsFromAssembly(typeof(FlightDbContext).Assembly);
        }
    }
}    