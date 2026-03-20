using System.ComponentModel.DataAnnotations;

namespace FlightApp.Domain.Entities
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }
        public Status Status { get; set; } = Status.Canceled;

        [Required]
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