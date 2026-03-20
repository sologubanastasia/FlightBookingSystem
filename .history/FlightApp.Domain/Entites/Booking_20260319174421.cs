using System.Data.Common;
using System.Reflection.Metadata;

namespace FlightApp.Domain.Entities
{
    public class Booking
    {
        public Guid Seat { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public Guid SeatNumber { get; set; }
        public  Status

    }
}