namespace FlightApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : BaseApiController
    {
        private readonly BookingsService _service;
        private readonly FlightDbContext _context;

        public BookingService(BookingService service)
        {
            _service = service;
        }


        [HttpGet("my")]
        public async Task<IActionResult> GetBookings()
        {
            var booking = await _service.GetUsersBookingsAsync(userId);
            return Ok(booking)
        }
    }
}