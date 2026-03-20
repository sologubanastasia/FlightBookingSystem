namespace FlightApp.WebApi.Controllers
{
    [ApiController]
    [Route("bookings")]
    public class BookingController
    {
        private readonly BookingsService _service;
        private readonly FlightDbContext _context;

        public BookingService(BookingService service)
        {
            _service = service;
        }


        
        public async Task<
    }
}