namespace FlightApp.Domain.Entities
{
    public class Seat
    {
        []
        public Guid Id { get; set; }
        public Guid FlightId { get; set; }
        public Flight Flight { get; set; }
        public int SeatNumber { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}