using System.Threading.Tasks;
using FlightApp.Domain.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FlightApp.Application.Dto.Flight;
using FlightApp.Application.Services;

namespace FlightApp.WebApi.Controllers
{
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
            var flights = await _service.GetAllFlightsAsync();
            return Ok(flights);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlightById(Guid id)
        {
            var flight = await _service.GetByIdAsync(id); 
            if (flight == null) return NotFound();
            return Ok(flight);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> CreateFlight([FromBody] CreateFlightDto dto)
        {
            var flight = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetFlightById), new { id = flight.Id }, flight);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateFlight(Guid id, [FromBody] UpdateFlightDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteFlight(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}