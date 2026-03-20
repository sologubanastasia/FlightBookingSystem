namespace FlightApp.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly FlightDbContext _context;
    
    public FlightRepository(FlightDbContext context)
    {
        _context = context;
    }

    async Task<IEnumerable<Booking>> GetBookingsByUserId(Guid userId)
    {
        await _context.Bookings.Include(b => b.BookingsSeats).ThenInclude(s => s.Seat).Include
    }
    Task<Booking?> GetByBookingIdAsync(Guid Id);
    Task AddAsync(Booking booking);
    void Delete(Booking booking);
    Task SveChangesAsync();
}