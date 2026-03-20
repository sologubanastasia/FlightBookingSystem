using AutoMapper;
using FlightApp.Application.Dto;
using FlightApp.Application.Interfaces;
using FlightApp.Domain.Entities;
using FlightApp.Domain.Interfaces;

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
        var flights = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<FlightDto>>(flights);
    }

    public async Task<FlightDto?> GetByIdAsync(Guid id)
    {
        var flight = await _repo.GetByIdAsync(id);
        return _mapper.Map<FlightDto>(flight);
    }

    public async Task<FlightDto> CreateAsync(CreateFlightDto dto)
    {
        var newFlight = _mapper.Map<Flight>(dto);
        newFlight.Id = Guid.NewGuid();
        
        string[] seatLetters = { "A", "B", "C", "D", "E", "F" };
        
        for (int row = 1; row <= 10; row++)
        {
            foreach (string letter in seatLetters)
            {
                newFlight.Seats.Add(new Seat 
                { 
                    Id = Guid.NewGuid(), 
                    SeatNumber = $"{row}{letter}", 
                    IsAvailable = true,
                    FlightId = newFlight.Id
                });
            }
        }

        await _repo.AddAsync(newFlight);
        return _mapper.Map<FlightDto>(newFlight);
    }

    public async Task UpdateAsync(Guid id, UpdateFlightDto dto)
    {
        var existingFlight = await _repo.GetByIdAsync(id);
        if (existingFlight == null) return;

        _mapper.Map(dto, existingFlight);
        await _repo.UpdateAsync(existingFlight);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repo.DeleteAsync(id);
    }
}