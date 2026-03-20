using System.Reflection.Metadata;

namespace FlightApp.Infrastructure
{

    public class FlightDbContext : IdentotyDbContext<UserStringHandle, IdentityRole<Guid>, Guid>
    {
        public FligthDbContext
        public OnModelConfigure(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(FlightDbContext)).Assembly;
        }
    }
}    