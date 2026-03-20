using Microdoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.E

namespace FlightApp.Infrastructure
{

    public class FlightDbContext : IdentityDbContext<UserStringHandle, IdentityRole<Guid>, Guid>
    {
        public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options);

        public DbSet<Booking> Bookings { get; set; } 
        public DbSet<BookingSeat> BookingSeats { get; set; } = null!;
        public DbSet<Flight> Flights { get; set; } 
        public DbSet<Seat> Seats { get; set;}

        public override void OnModelConfigure(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(FlightDbContext)).Assembly;
        }
    }
}    