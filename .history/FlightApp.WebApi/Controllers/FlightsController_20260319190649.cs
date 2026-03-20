using System.ComponentModel.Design;

namespace FlightApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : BaseApiController
    {
        private readonly IFlightService _service;

        public FlightsController(IFlightService service)
        {
            _service = service;
        }

        [HttpGet("{flights}")]
        public async Task<IActionResult> GetBookings()
        {
            return await _service.GetAllBookingsAsync();
        }

        public async Task<IActionResult> CreateFlight([FromBody] CreateFlight)
    }
}