namespace FlightApp.Application.Dto.Booking;

public record CreateBookingDto(
    string FlightNumber,
    string Destination,
    DateTime 
);