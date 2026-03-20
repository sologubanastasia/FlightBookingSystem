namespace FlightApp.Application.Dto.Booking;

public record CreateBookingDto(
    Guid FlightId,
    List<Guid> SeatI
);