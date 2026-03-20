namespace FlightApp.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public ICollection<Booking> Bookings = new List<Booking>();
    }
}