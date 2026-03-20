namespace FlightApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController
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
            
        }
    }
}