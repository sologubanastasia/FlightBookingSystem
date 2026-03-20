namespace FlightApp.Domain.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetBookingsByUserId(Guid userId);
        Task<Booking?> GetByBookingIdAsync(Guid Id);
        Task AddAsync(Booking booking);
        
    }
}