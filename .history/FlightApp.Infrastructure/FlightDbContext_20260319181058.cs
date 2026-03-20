using System.Reflection.Metadata;

namespace FlightApp.Infrastructure
{

    public class FlightDbContext : IdentotyDbContext<UserStringHandle, IdentityRole<Guid>, Guid>
    {
        public OnModelConfigure(ModelBuilder builder)
        {
            base.OnModelCreating(builder)
        }
    }
}    