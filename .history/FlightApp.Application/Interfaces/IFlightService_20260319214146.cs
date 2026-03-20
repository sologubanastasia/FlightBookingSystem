using FlightApp.Application.Mapper;
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