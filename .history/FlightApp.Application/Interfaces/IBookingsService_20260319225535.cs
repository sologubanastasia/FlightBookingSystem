using FlightApp.Application.Dto.Booking;
namespace FlightApp.Application.Interfaces;

public interface IBookingService
{
    Task<BookingDto> CreateBookingAsync(CreateBookingDto dto, Guid userId);
    Task<IEnumerable<BookingDto>> GetUserBookingsAsync(Guid userId);
    Task<bool> CancelBookingAsync(Guid bookingId);
}