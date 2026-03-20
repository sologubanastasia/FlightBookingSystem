using FlightApp.Domain.Entity
namespace FlightApp.Domain.Interfaces
{
    public interface IFlightRepository
    {
        Task<IEnumerable<Flight>>
    }
}