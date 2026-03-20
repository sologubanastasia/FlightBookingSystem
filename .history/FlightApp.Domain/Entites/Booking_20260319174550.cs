using System.Data.Common;
using System.Net;
using System.Reflection.Metadata;

namespace FlightApp.Domain.Entities
{
    public class Booking
    {
        public Guid Seat { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public Guid SeatNumber { get; set; }
        public Status Status { get; set; } = Status.Canceled;

    }

    public enum Status
    {
        Canceled = 1,
        Con
    }
}