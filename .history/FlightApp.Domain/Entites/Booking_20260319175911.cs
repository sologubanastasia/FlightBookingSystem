using System.Data.Common;
using System.Net;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace FlightApp.Domain.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }
        public ICollection<Seat> Seats { get; set; } = new List<SearchOption>
        public string UserId { get; set; }
        public User User { get; set; }
        public Guid SeatNumber { get; set; }
        public Status Status { get; set; } = Status.Canceled;

    }

    public enum Status
    {
        Canceled = 1,
        Confirmed = 2
    }
}