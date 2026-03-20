using FlightApp.Application.Dto.Booking;
namespace FlightApp.Application.Interfaces;

public interface IBookingService
{
    Task<BookingDto> CreateBookingAsync(Guid userId, CreateBookingDto dto);
    Task<IEnumerable<BookingDto>> GetUserBookingsAsync(Guid userId);
    Task<bool> CancelBookingAsync(Guid bokingId, Guid userId);
}