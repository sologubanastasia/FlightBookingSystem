namespace FlightApp.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly FlightDbContext _context;
    
    public FlightRepository(FlightDbContext context)
    {
        _context = context;
    }
    
    Task<IEnumerable<Booking>> GetBookingsByUserId(Guid userId)
    {
        
    }
    Task<Booking?> GetByBookingIdAsync(Guid Id);
    Task AddAsync(Booking booking);
    void Delete(Booking booking);
    Task SveChangesAsync();
}