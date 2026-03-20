using FlightApp.Domain.Entities;
namespace FlightApp.Domain.Interfaces
{
    public interface ISeatRepository
    {
        Task<IEnumerable<Seat>> GetAllAsync();
        Task<IEnumerable<Seat>> Get
        void UpdateSeats(IEnumerable<Seat> seats);
    }
}