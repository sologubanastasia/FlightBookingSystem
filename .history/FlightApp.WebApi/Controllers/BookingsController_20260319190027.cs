namespace FlightApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            var booking = await _service.GetUsersBookingsAsync(userId);
            return Ok(booking);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDto dto)
        {
            var result = await _service.CreateBookingAsync(UserId);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(Guid id)
        {
            await _service.CancelBookingAsync(id, UserId);
            return NoContent();
        }
    }
}