using FlightApp.Domain.Entities;
namespace FlightApp.Domain.Interfaces
{
    public interface IFlightRepository
    {
        Task<IEnumerable<Flight>>
    }
}