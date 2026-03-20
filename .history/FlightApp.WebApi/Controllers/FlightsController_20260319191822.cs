using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<IActionResult> GetFlights()
        {
            return await _service.GetAllFlightsAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlightById(Guid flightId)
        {
            var flight = await _service.GetFlightByIdAsync(Id);
            if(flight == null)
            {
                return NotFound();
            }

            return Ok(flight);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateFlight([FromBody] CreateFlightDto dto)
        {
            var flight = await _service.CreateFlightAsync(dto);
            return CreateAtAction(nameof(GetById), new { id = flight.Id }, flight);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight(Guid id, [FromBody] UpdateDlightDto dto)
        {
            await _service.UpdateFlightAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<AsyncTaskMethodBuilder<IActionResult>> DeleteFlight(Guid id)
        {
            await _service.DeleteFligt=ht
        }
    }
}