using FlightApp.Domain.Entities;
namespace FlightApp.Domain.Interfaces
{
    public interface ISeatRepository
    {
        Task<IEnumerable<Seat>> GetSeatsByFlightIdAsync(Guid flightId);
    Task<IEnumerable<Seat>> GetByIdsAsync(IEnumerable<Guid> ids);
    Task UpdateAsync(Seat seat);

    // 3. Додаємо UpdateRange, якщо хочеш оновлювати список одним махом
    void UpdateRange(IEnumerable<Seat> seats);
    }
}