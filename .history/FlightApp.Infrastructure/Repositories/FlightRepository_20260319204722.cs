using System.Threading.Tasks;

namespace FlightApp.Infrastructure.Repositories;

public class FlightRepository : IFlightRepository
{
    private readonly FlightDbContext _context;
    
    public FlightRepository(FlightDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Flight>> GetAllAsync()
    {
        return await _context.Flights.Include(f => f.Seats).ToListAsync();
    }

    public async Task<Flight?> GetByIdAsync(Guid flightId)
    {
        return await _context.Flights.Include(f => f.Seats).FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task AddAsync(Flight flight)
    {
        return await _context.Flights.AddAsync(flight);
    }

    public async Task Update(Flight flight)
    {
        return await _context.Flights.Update(flight);
    }

    public void Delete(Flight flight)
    {
        _context.Flights.Remove(flight);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}