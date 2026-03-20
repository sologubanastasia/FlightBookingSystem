using Fli
namespace FlightApp.Application.Dto.Booking;

public record BookingDto(
    Guid Id, 
    Guid FlightId, 
    DateTime BookingDate, 
    string Status, 
    List<SeatDto> Seats
);