using System.Reflection.Metadata;

namespace FlightApp.Infrastructure
{

    public class FlightDbContext : IdentotyDbContext<UserStringHandle, IdentityRole<Guid>, Guid>
    {
        public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options);

        public DbSet<Booking> Bookings { get; set; } 
        public DbSet<BookingSeat> BookingSeats { get; set; } = null!;
        public DbSet<Flight> Flights { get; set; } 
        public DbSet<User> Users { get; set; }
        public DbSet<Seat
        public OnModelConfigure(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(FlightDbContext)).Assembly;
        }
    }
}    