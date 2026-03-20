namespace FlightApp.Application.Dto.Flight;

public record UpdateFlightDto(
    string FlightNumber,
    string Destination,
    DateTime DepartureTime,
    DateTime ArrivalTime
);yfg