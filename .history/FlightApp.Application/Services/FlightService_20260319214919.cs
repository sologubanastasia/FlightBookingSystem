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

    // 1. Отримуємо всі рейси
    public async Task<IEnumerable<FlightDto>> GetAllFlightsAsync()
    {
        var flightsFromDb = await _repo.GetAllAsync();
        
        // Перетворюємо список сутностей у список DTO для клієнта
        var flightDto = _mapper.Map<IEnumerable<FlightDto>>(flightsFromDb);
        
        return flightDto;
    }

    // 2. Отримуємо один рейс за ID
    public async Task<FlightDto?> GetByIdAsync(Guid id)
    {
        var flight = await _repo.GetByIdAsync(id);
        
        // Якщо рейс не знайдено, маппер просто поверне null
        return _mapper.Map<FlightDto>(flight);
    }

    // 3. Створюємо новий рейс + генеруємо крісла
    public async Task<FlightDto> CreateAsync(CreateFlightDto dto)
    {
        // Перетворюємо вхідні дані (DTO) у сутність бази даних
        var newFlight = _mapper.Map<Flight>(dto);
        
        // Логіка створення місць (10 рядів по 6 місць)
        string[] seatLetters = { "A", "B", "C", "D", "E", "F" };
        
        for (int row = 1; row <= 10; row++)
        {
            foreach (string letter in seatLetters)
            {
                var newSeat = new Seat 
                { 
                    Id = Guid.NewGuid(), 
                    SeatNumber = row.ToString() + letter, // Наприклад: "1A", "1B"
                    IsAvailable = true 
                };
                
                newFlight.Seats.Add(newSeat);
            }
        }

        // Зберігаємо в базу
        await _repo.AddAsync(newFlight);
        await _repo.SaveChangesAsync();
        
        // Повертаємо створений рейс назад клієнту
        return _mapper.Map<FlightDto>(newFlight);
    }

    // 4. Оновлюємо дані рейсу
    public async Task UpdateAsync(Guid id, UpdateFlightDto dto)
    {
        var existingFlight = await _repo.GetByIdAsync(id);
        
        // Якщо рейсу немає — нічого не робимо
        if (existingFlight == null)
        {
            return; 
        }

        // Копіюємо дані з DTO в існуючий об'єкт
        _mapper.Map(dto, existingFlight);
        
        _repo.Update(existingFlight);
        await _repo.SaveChangesAsync();
    }

    // 5. Видаляємо рейс
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