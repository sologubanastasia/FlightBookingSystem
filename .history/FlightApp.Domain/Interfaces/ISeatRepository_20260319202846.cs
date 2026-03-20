using FlightApp.Domain.Entities;
namespace FlightApp.Domain.Interfaces
{
    public interface ISeatRepository
    {
        Task<IEnumerable<Seat>> GetSea();
        Task<IEnumerable<Seat>> GetBySeatIdAsync(IEnumerable<Guid> seats);
        void UpdateSeats(IEnumerable<Seat> seats);
    }
}