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
    async Task AddAsync(FlightApp flight)
    {
        return await _context.AddAsync()
    }
    void Update(FlightApp flight);
    void Delete(FlightApp flight);
    Task SaveChangesAsync();
}