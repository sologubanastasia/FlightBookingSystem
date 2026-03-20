using FlightApp.Application.Dto;

namespace FlightApp.Application.Interfaces;

public interface IBookingService
{
    // Другий параметр МАЄ бути Guid userId
    Task<BookingDto> CreateBookingAsync(CreateBookingDto dto, Guid userId);
    
    Task<IEnumerable<BookingDto>> GetUserBookingsAsync(Guid userId);
    
    // Параметр МАЄ бути Guid bookingId
    Task<bool> CancelBookingAsync(Guid bookingId);
}