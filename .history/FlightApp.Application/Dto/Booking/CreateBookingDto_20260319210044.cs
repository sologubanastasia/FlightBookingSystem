namespace FlightApp.Application.Dto.Booking;

public record CreateBookingDto(
    Guid Id, 
    Guid FlightId, 
    DateTime BookingDate, 
    string Status, 
    List<SeatDto> Seats
);