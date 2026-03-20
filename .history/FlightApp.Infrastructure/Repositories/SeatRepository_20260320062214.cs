using FlightApp.Domain.Entities;
using FlightApp.Domain.Interfaces;
namespace FlightApp.Infrastructure.Repositories;

public class SeatRepository : ISeatRepository
{
    private readonly FlightDbContext _context;
    
    public SeatRepository(FlightDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Seat>> GetSeatsByFlightIdAsync(Guid flightId)
    {
        return await _context.Seats.Where(s => s.FlightId == flightId).ToListAsync();
    }

    public async Task<IEnumerable<Seat>> GetByIdsAsync(IEnumerable<Guid> ids)
    {
        return await _context.Seats.Where(s => ids.Contains(s.Id)).ToListAsync();
    }
    
    public async Task UpdateAsync(Seat seat)
    {
        _context.Seats.Update(seat);
        await Task.CompletedTask;
    }

    public void UpdateAsync(IEnumerable<Seat> seats)
    {
        _context.Seats.UpdateRange(seats);
    }
}