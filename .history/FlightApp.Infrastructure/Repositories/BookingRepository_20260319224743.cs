using FlightApp.Domain.Entities;
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
        await _context.Bookings.Include(b => b.BookingsSeats).ThenInclude(s => s.Seat).Include(b => b.Flight).Where(b => b.UserId == userId).ToListAsync();
    }
    async Task<Booking?> GetByBookingIdAsync(Guid Id)
    {
        return await _context.Bookings.Include(b => b.BookingSeats).FirstOrDefaultAsync(b => b.Id == Id);
    }
    async Task AddAsync(Booking booking)
    {
        return await _context.Bookings.AddAsync(booking);
    }
    void Delete(Booking booking)
    {
        return _context.Bookings.Remove(booking);
    }
    async Task SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}