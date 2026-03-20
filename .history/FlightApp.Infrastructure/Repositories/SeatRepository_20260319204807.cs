namespace FlightApp.Infrastructure.Repositories;

public class FlightRepository : ISeatRepository
{
    private readonly FlightDbContext _context;
    
    public FlightRepository(FlightDbContext context)
    {
        _context = context;
    }

}