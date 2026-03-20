using FlightApp.Domain.Entities;
using FlightApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlightApp.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly FlightDbContext _context;

    public BookingRepository(FlightDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Booking>> GetUserBookingsAsync(Guid userId)
    {
        return await _context.Bookings
            .Include(b => b.BookingSeats)
            .ThenInclude(s => s.Seat)
            .Where(b => b.UserId == userId)
            .ToListAsync();
    }

    public async Task<Booking?> GetByIdAsync(Guid id)
    {
        return await _context.Bookings
            .Include(b => b.BookingSeats)
            .ThenInclude(s => s.Seat)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task AddAsync(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
    }

    public void Delete(Booking booking)
    {
        _context.Bookings.Remove(booking);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}