using System.Reflection.Metadata;

namespace FlightApp.Domain.Entities
{
    public class Booking
    {
        public Guid Seat { get; set; }
        public User User
    }
}