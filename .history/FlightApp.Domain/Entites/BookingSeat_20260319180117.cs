namespace FlightApp.Domain.Entities
{
    public class BookingSeat
    {
        public Guid BookingId { get; set; }
        public Booking Booking { get; set; }
        public Guid SeatId { get; set; }
        public BookingSeat BookingSeat { get; set; }
    }
}