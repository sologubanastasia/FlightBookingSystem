namespace FlightApp.Infrastructure.Repositories;

public class SeatRepository : ISeatRepository
{
    private readonly FlightDbContext _context;
    
    public FlightRepository(FlightDbContext context)
    {
        _context = context;
    }

     Task<IEnumerable<Seat>> GetSeatsByFlightIdAsync(Guid flightId);
    Task<IEnumerable<Seat>> GetBySeatIdAsync(IEnumerable<Guid> seats)

    public void UpdateSeats(IEnumerable<Seat> seats)
    {
        
    }
}