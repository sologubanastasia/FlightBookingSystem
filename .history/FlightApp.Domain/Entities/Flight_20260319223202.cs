using System.ComponentModel.DataAnnotations;
using System
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

        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        [MaxLength(100)]
        public string Destination { get; set; }
        public virtual ICollection<Seat> Seats { get; set;}  = new List<SearchOption>();
    }
}