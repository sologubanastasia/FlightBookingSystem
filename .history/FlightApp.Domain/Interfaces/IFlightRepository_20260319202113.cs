using FlightApp.Domain.
namespace FlightApp.Domain.Interfaces
{
    public interface IFlightRepository
    {
        Task<IEnumerable<Flight>>
    }
}