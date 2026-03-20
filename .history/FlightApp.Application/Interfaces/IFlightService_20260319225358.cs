using FlightApp.Application.Mapper;
using FlightApp.Application.Dto;
namespace FlightApp.Application.Services
{
    public interface IFlightService
    {
        Task<IEnumerable<FlightDto>> GetAllFlightsAsync();
        Task<FlightDto?> GetByIdAsync(Guid id);
        Task<FlightDto> CreateAsync(CreateFlightDto dto);
        Task UpdateAsync(Guid id, UpdateFlightDto dto);
        Task DeleteAsync(Guid id);
    }
}