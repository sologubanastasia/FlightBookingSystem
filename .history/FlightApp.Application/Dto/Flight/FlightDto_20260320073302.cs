using FlightApp.Application.Dto.Seat;
namespace FlightApp.Application.Dto.Flight;

public record FlightDto(
    Guid d,
    string FlightNumber,
    string Destination,
    DateTime DepartureTime,
    DateTime ArrivalTime,
    ICollection<SeatDto> Seats
);