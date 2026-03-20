using System.Reflection.Metadata;

namespace FlightApp.Infrastructure
{

    public class FlightDbContext : IdentotyDbContext<UserStringHandle, IdentityRole<Guid>, Guid>
    {
        public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options);

        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<BookingSeat> BookingSeats { get; set; } = 

        public OnModelConfigure(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(FlightDbContext)).Assembly;
        }
    }
}    