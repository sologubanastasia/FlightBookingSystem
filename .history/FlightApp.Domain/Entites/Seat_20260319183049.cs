using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightApp.Domain.Entities
{
    public class Seat
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid FlightId { get; set; }
        public Flight Flight { get; set; }

        [Required]
        [MaxLength(10)]
        public int SeatNumber { get; set; }

        [ForeignKey(nameof()]
        public bool IsAvailable { get; set; } = true;
    }
}