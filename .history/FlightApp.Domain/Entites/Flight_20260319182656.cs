using System.ComponentModel.DataAnnotations;

namespace FlightApp.Domain.Entities
{
    public class Flight
    {
        [Key]
        public Guid Id { get; set; }
        public int FlightNumber { get; set; }
        public  DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Destination { get; set; }
        public ICollection<Seat> Seats = new List<SearchOption>();
    }
}