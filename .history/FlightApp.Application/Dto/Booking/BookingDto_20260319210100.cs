namespace FlightApp.Application.Dto.Booking;

public record CreateBookingDto(
    Guid FlightId,
    List<Guid> Seats
);
namespace FlightApp.Application.Dto.Booking;

public record BookingDto(
    Guid Id, 
    Guid FlightId, 
    DateTime BookingDate, 
    string Status, 
    List<SeatDto> Seats
);