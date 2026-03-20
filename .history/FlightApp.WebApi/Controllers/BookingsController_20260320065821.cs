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
            var booking = await _bookingService.GetUsersBookingsAsync(UserId);
            return Ok(booking);
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
            await _bookingService.CancelBookingAsync(UserId, id);
            return NoContent();
        }
    }
}