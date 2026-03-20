using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authrization;
using FlightApp.Application.Interfaces;
using FlightApp.Application.Dto.Booking;
namespace FlightApp.WebApi.Controllers
{
    [Authorized]
    public class BookingController : BaseApiController
    {
        private readonly BookingsService _service;

        public BookingService(BookingService service)
        {
            _service = service;
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