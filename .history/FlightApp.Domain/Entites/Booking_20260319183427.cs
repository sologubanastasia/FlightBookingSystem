using System.ComponentModel.DataAnnotations;

namespace FlightApp.Domain.Entities
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public virtual Status Status { get; set; } = Status.Canceled;

        [Required]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<BookingSeat> Seats { get; set; } = new List<BookingSeat>();
    }

    public enum Status
    {
        Canceled = 1,
        Confirmed = 2
    }
}