using System.Reflection.Metadata;

namespace FlightApp.Infrastructure
{

    public class FlightDbContext : IdentotyDbContext<UserStringHandle, IdentityRole<Guid> 
    {
        public OnModelConfigure()
    }
}    