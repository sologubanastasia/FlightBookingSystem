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
        public async Task<IActionResult> GetFlights()
        {
            return await _service.GetAllFlightsAsync();
        }

        [HttpGet]
        public async Task<IActionResult> CreateFlight([FromBody] CreateFlightDto dto)
        {
            var flight = await _service.CreateFlightAsync(dto);
            return CreateAtAction(nameof(GetById), new { id = flight.Id }, flight);
        }
    }
}