using FlightApp.Domain.Entities;
namespace FlightApp.Domain.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetUserBookingsAsync(Guid userId);
    
    // 2. Змінюємо назву на GetByIdAsync (стандарт для репозиторіїв)
    Task<Booking?> GetByIdAsync(Guid id);
    
    Task AddAsync(Booking booking);
    
    void Delete(Booking booking);
    
    Task SaveChangesAsync();
    }
}