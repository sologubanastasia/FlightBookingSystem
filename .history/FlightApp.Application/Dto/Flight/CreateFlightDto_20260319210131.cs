namespace FlightApp.Application.Dto.Flight;

public record CreateFlightDto(
    string FlightNumber, 
    string Destination, 
    DateTime DepartureTime, 
    DateTime ArrivalTime
);