using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FlightApp.Application.Interfaces;
using FlightApp.Application.Dto.Booking;
using FlightApp.Application.Services;
namespace FlightApp.WebApi.Controllers
{
    [Authorize]
    public class BookingController : BaseApiController
    {
        private readonly IBookingService _bookingService;

        public BookingController(BookingService service)
        {
            _bookingService = bookingService;
        }


        [HttpGet("my")]
        public async Task<IActionResult> GetBookings()
        {
            var booking = await _service.GetUsersBookingsAsync(UserId);
            return Ok(booking);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDto dto)
        {
            var result = await _service.CreateBookingAsync(UserId, dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(Guid bookingId)
        {
            await _service.CancelBookingAsync(UserId, bookingId);
            return NoContent();
        }
    }
}