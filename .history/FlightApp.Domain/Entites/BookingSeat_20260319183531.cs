using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightApp.Domain.Entities
{
    public class BookingSeat
    {
        [Required]
        public Guid BookingId { get; set; }

        [ForeignKey(nameof(BookingId))]
        public virtual Booking Booking { get; set; } = !

        [Required]
        public Guid SeatId { get; set; }

        [ForeignKey(nameof(SeatId))]
        public virtual Seat Seat { get; set; }
    }
}