namespace FlightApp.Application.Dto.Flight;

public record FlightDto(
    Guid id,
    string FlightNumber,
    string Destination,
    DateTime DepartureTime,
    DateTime ArrivalTime,
    IC
);