using FlightApp.Domain.Entities;
using FlightApp.Domain.Interfaces;
namespace FlightApp.Infrastructure.Repositories;

public class SeatRepository : ISeatRepository
{
    private readonly FlightDbContext _context;
    
    public FlightRepository(FlightDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Seat>> GetSeatsByFlightIdAsync(Guid flightId)
    {
        return await _context.Seats.Where(s => s.FlightId == flightId).ToListAsync();
    }

    public async Task<IEnumerable<Seat>> GetBySeatIdAsync(IEnumerable<Guid> seats)
    {
        rawai_context.Seats.Where(s => seats.Contains(s.Id)).ToListAsync();
    }

    public void UpdateAsync(IEnumerable<Seat> seats)
    {
        _context.Seats.UpdateRange(seats);
    }
}