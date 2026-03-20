using System.ComponentModel.DataAnnotations;

namespace FlightApp.Domain.Entities
{
    public class BookingSeat
    {
        [Required]
        public Guid BookingId { get; set; }
        public Booking Booking { get; set; }
        public Guid SeatId { get; set; }
        public Seat Seat { get; set; }
    }
}