using System.Reflection.Metadata;

namespace FlightApp.Infrastructure
{

    public class FlightDbContext : IdentotyDbContext<UserStringHandle, IdentityRole<Guid>, Guid>
    {
        public FlightDbContext(DbContextOptions)
        public OnModelConfigure(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(FlightDbContext)).Assembly;
        }
    }
}    