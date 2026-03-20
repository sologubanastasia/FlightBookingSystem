namespace FlightApp.Domain.Entities
{
    public class Flight
    {
        public Guid Id { get; set; }
        public int FlightNumber { get; set; }
        public  DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Destination { get; set; }
        public ICollection<Seat>
    }
}