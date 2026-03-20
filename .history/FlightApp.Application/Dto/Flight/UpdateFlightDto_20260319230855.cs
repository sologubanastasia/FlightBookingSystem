namespace FlightApp.Application.Dto.Seat;

public record SeatDto(
    string FlightNumber,
    string Destination,
    DateTime DepartureTime,
    DateTime ArrivalTime
);