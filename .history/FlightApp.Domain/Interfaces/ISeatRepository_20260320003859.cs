using FlightApp.Domain.Entities;
namespace FlightApp.Domain.Interfaces
{
    public interface ISeatRepository
    {
        Task<IEnumerable<Seat>> GetSeatsByFlightIdAsync(Guid flightId);
        Task<IEnumerable<Seat>> GetByIdAsync(IEnumerable<Guid> seats);
        Task UpdateAsync(IEnumerable<Seat> seats);
    }
}