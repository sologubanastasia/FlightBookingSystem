using FlightApp.Domain.Entities;
namespace FlightApp.Domain.Interfaces
{
    public interface ISeatRepository
    {
        Task<IEnumerable<Seat>> GetSeatsByFlightIdAsync(Guid flightId);

    // 1. Змінюємо назву на GetByIdsAsync (як у BookingService)
    Task<IEnumerable<Seat>> GetByIdsAsync(IEnumerable<Guid> ids);

    // 2. Додаємо метод для оновлення одного місця (або колекції)
    Task UpdateAsync(Seat seat);

    // 3. Додаємо UpdateRange, якщо хочеш оновлювати список одним махом
    void UpdateRange(IEnumerable<Seat> seats);
    }
}