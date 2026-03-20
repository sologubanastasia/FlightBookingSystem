using FlightApp.Application.Dto.Seat;
namespace FlightApp.Application.Dto.Booking;

public class BookingDto
{
    public Guid Id { get; init; }
    public Guid FlightId { get; init; }
    public DateTime BookingDate { get; init; }
    public string Status { get; init; }
    public List<SeatDto> Seats { get; init; }
    // Порожній конструктор для AutoMapper
    public BookingDto() { } 
}