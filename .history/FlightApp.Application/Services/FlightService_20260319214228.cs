using FlightApp.Application.Mapper;
using FlightApp.Application.Interfaces;
namespace FlightApp.Application.Services
{
    namespace FlightApp.Application.Services;

public class FlightService : IFlightService
{
    private readonly IFlightRepository _repo;
    private readonly IMapper _mapper;

    public FlightService(IFlightRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FlightDto>> GetAllFlightsAsync() 
        => _mapper.Map<IEnumerable<FlightDto>>(await _repo.GetAllAsync());

    public async Task<FlightDto?> GetByIdAsync(Guid id)
    {
        var flight = await _repo.GetByIdAsync(id);
        return _mapper.Map<FlightDto>(flight);
    }

    public async Task<FlightDto> CreateAsync(CreateFlightDto dto)
    {
        var flight = _mapper.Map<Flight>(dto);
        
        string[] letters = { "A", "B", "C", "D", "E", "F" };
        for (int i = 1; i <= 10; i++)
        {
            foreach (var l in letters)
            {
                flight.Seats.Add(new Seat { 
                    Id = Guid.NewGuid(), 
                    SeatNumber = $"{i}{l}", 
                    IsAvailable = true 
                });
            }
        }

        await _repo.AddAsync(flight);
        await _repo.SaveChangesAsync();
        return _mapper.Map<FlightDto>(flight);
    }

    public async Task UpdateAsync(Guid id, UpdateFlightDto dto)
    {
        var flight = await _repo.GetByIdAsync(id);
        if (flight == null) return;

        _mapper.Map(dto, flight);
        _repo.Update(flight);
        await _repo.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var flight = await _repo.GetByIdAsync(id);
        if (flight != null)
        {
            _repo.Delete(flight);
            await _repo.SaveChangesAsync();
        }
    }
}
}