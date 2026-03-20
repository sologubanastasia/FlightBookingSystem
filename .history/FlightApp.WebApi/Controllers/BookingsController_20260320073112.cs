using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FlightApp.Application.Interfaces;
using FlightApp.Application.Dto.Booking;
using System.Threading.Tasks;

namespace FlightApp.WebApi.Controllers
{
    [Authorize]
    public class BookingController : BaseApiController
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("my")]
        public async Task<IActionResult> GetBookings()
        {
            var bookings = await _bookingService.GetUserBookingsAsync(UserId);
            return Ok(bookings);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDto dto)
        {
            var result = await _bookingService.CreateBookingAsync(UserId, dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(Guid id)
        {
            await _bookingService.CancelBookingAsync(id, UserId);
            return NoContent();
        }
    }
}