namespace FlightApp.Application.Dto.Seat;

public record UpdateFlightDto(
    string FlightNumber,
    string Destination,
    DateTime DepartureTime,
    DateTime ArrivalTime
);