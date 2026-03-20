namespace FlightApp.Infrastructure.Repositories;

public class FlightRepository : IFlightRepository
{
    private readonly FlightDbContext _context;
    
    public FlightRepository(FlightDbContext context)
    {
        _context = context;
    }

    Task<IEnumerable<Flight>> GetAllAsync();
    Task<Flight?> GetByIdAsync(Guid flightId);        Task AddAsync(FlightApp flight);
        void Update(FlightApp flight);
        void Delete(FlightApp flight);
        Task SaveChangesAsync();
}