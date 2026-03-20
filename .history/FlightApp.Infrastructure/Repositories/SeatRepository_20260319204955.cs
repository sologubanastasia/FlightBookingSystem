namespace FlightApp.Infrastructure.Repositories;

public class SeatRepository : ISeatRepository
{
    private readonly FlightDbContext _context;
    
    public FlightRepository(FlightDbContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<Seat>> GetSeatsByFlightIdAsync(Guid flightId)
    {
        return await _context.Seats.Where(s => s.FlightId == flightId).ToListAsync();
    }

    public Task<IEnumerable<Seat>> GetBySeatIdAsync(IEnumerable<Guid> seats)
    {
        return await _context.Seats.Where(s => seats.Contains(s.Id)).ToListAsync();
    }

    public void UpdateSeats(IEnumerable<Seat> seats)
    {
        
    }
}