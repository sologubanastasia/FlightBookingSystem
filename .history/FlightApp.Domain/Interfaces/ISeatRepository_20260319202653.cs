using FlightApp.Domain.Entities;
namespace FlightApp.Domain.Interfaces
{
    public interface ISeatRepository
    {
        Task<IEnumerable<Seat>> GetAllAsync();
        Task<Flight?> GetByIdAsync(Guid flightId);
        Task AddAsync(FlightApp flight);
        void UpdateSeat(FlightApp flight);
    }
}