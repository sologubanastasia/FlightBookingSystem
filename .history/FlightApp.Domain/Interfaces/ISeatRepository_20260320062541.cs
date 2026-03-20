using FlightApp.Domain.Entities;
namespace FlightApp.Domain.Interfaces
{
    public interface ISeatRepository
    {
        Task<IEnumerable<Seat>> GetSeatsByFlightIdAsync(Guid flightId);
        Task<IEnumerable<Seat>> GetByIdsAsync(IEnumerable<Guid> ids);
        void Update(IEnumerable<Seat> seats);
        
    public void Update(IEnumerable<Seat> seats);
    }
}