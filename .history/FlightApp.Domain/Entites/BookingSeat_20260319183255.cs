using System.ComponentModel.DataAnnotations;

namespace FlightApp.Domain.Entities
{
    public class BookingSeat
    {
        [Required]
        public Guid BookingId { get; set; }

        [ForeignKey]
        public Booking Booking { get; set; }

        [Required]
        public Guid SeatId { get; set; }
        public Seat Seat { get; set; }
    }
}