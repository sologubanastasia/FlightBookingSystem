using Microsoft.AspNetCore.Identity;
namespace FlightApp.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public virtual ICollection<Booking> Bookings = new List<Booking>();
    }
}