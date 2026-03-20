using System.ComponentModel.DataAnnotations;

namespace FlightApp.Domain.Entities
{
    public class Flight
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string FlightNumber { get; set; }

        [Required]
        public  DateTime DepartureTime { get; set; }

        [Requuired]
        public DateTime ArrivalTime { get; set; }
        public string Destination { get; set; }
        public ICollection<Seat> Seats = new List<SearchOption>();
    }
}