using FlightApp.Application.Dto.Flight;
using FlightApp.Application.Interfaces;
using FlightApp.Domain.Entities;
using FlightApp.Domain.Interfaces;
using AutoMapper;

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
    {
        var flightsFromDb = await _repo.GetAllAsync();
        var flightDto = _mapper.Map<IEnumerable<FlightDto>>(flightsFromDb);
        
        return flightDto;
    }

    public async Task<FlightDto?> GetByIdAsync(Guid id)
    {
        var flight = await _repo.GetByIdAsync(id);
        return _mapper.Map<FlightDto>(flight);
    }

    public async Task<FlightDto> CreateAsync(CreateFlightDto dto)
    {
        var newFlight = _mapper.Map<Flight>(dto);

        string[] seatLetters = { "A", "B", "C", "D", "E", "F" };
        
        for (int row = 1; row <= 10; row++)
        {
            foreach (string letter in seatLetters)
            {
                var newSeat = new Seat 
                { 
                    Id = Guid.NewGuid(), 
                    newSeatюSeatNumber = row.ToString() + letter, 
                    IsAvailable = true 
                };
                
                newFlight.Seats.Add(newSeat);
            }
        }
        await _repo.AddAsync(newFlight);
        await _repo.SaveChangesAsync();
        
        return _mapper.Map<FlightDto>(newFlight);
    }

    public async Task UpdateAsync(Guid id, UpdateFlightDto dto)
    {
        var existingFlight = await _repo.GetByIdAsync(id);
        if (existingFlight == null)
        {
            return; 
        }

        _mapper.Map(dto, existingFlight);
        
        _repo.Update(existingFlight);
        await _repo.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var flightToDelete = await _repo.GetByIdAsync(id);
        
        if (flightToDelete != null)
        {
            _repo.Delete(flightToDelete);
            await _repo.SaveChangesAsync();
        }
    }
}