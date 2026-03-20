using System.ComponentModel.DataAnnotations;

namespace FlightApp.Domain.Entities
{
    public class Seat
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid FlightId { get; set; }

        [Required]
        public Flight Flight { get; set; }
        
        [Required]
        [MaxLength(10)]
        public int SeatNumber { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}