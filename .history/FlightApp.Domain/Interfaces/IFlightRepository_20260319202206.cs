using FlightApp.Domain.Entities;
namespace FlightApp.Domain.Interfaces
{
    public interface IFlightRepository
    {
        Task<IEnumerable<Flight>> GetAllAsync();
        Task<Flight?> GetByIdAsync(Guid flightId);
        Task
    }
}