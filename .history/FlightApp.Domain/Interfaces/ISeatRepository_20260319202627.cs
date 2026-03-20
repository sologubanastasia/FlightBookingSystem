using FlightApp.Domain.Entities;
namespace FlightApp.Domain.Interfaces
{
    public interface ISeatRepository
    {
        Task<IEnumerable<Flight>> GetAllAsync();
        Task<Flight?> GetByIdAsync(Guid flightId);
        Task AddAsync(FlightApp flight);
        void Update(FlightApp flight);
        void Delete(FlightApp flight);
        Task SaveChangesAsync();
    }
}