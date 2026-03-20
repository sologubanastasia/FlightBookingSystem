using FlightApp.Domain.Entities;
namespace FlightApp.Domain.Interfaces
{
    public interface ISeatRepository
    {
        Task<IEnumerable<Seat>> GetAllAsync();
        Task<IEnumerable<Sea
        void UpdateSeats(IEnumerable<Seat> seats);
    }
}