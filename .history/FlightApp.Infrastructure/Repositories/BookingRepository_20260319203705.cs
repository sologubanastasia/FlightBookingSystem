namespace FlightApp.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    Task<IEnumerable<Booking>> GetBookingsByUserId(Guid userId);
    Task<Booking?> GetByBookingIdAsync(Guid Id);
        Task AddAsync(Booking booking);
        void Delete(Booking booking);
        Task SveChangesAsync();
}