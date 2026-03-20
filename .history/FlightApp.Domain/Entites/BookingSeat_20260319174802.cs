namespace FlightApp.Domain.Entities
{
    public class BookingSeat
    {
        public BookingSeat Booking { get }
        public Guid SeatId { get; set; }
        public BookingSeat BookingSeat { get; set; }
    }
}