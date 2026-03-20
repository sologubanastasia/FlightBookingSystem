using System.
namespace FlightApp.Domain.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Status Status { get; set; } = Status.Canceled;
        public Guid UserId { get; set; }
        public User User { get; set; }
         public ICollection<Seat> Seats { get; set; } = new List<Seat>();
    }

    public enum Status
    {
        Canceled = 1,
        Confirmed = 2
    }
}