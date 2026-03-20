using System.ComponentModel.Design;
using System.Threading.Tasks;
using FlightApp.Domain.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FlightApp.Application.Interfaces;
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
        public async Task<IActionResult> GetFlightById(Guid flightId)
        {
            var flight = await _service.GetFlightByIdAsync(id); 
            if (flight == null) 
                return NotFound();
            return Ok(flight);
            }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> CreateFlight([FromBody] CreateFlightDto dto)
        {
            var flight = await _service.CreateFlightAsync(dto);
            return CreateAtAction(nameof(GetFlightById), new { id = flight.Id }, flight);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight(Guid id, [FromBody] UpdateFlightDto dto)
        {
            await _service.UpdateFlightAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult> DeleteFlight(Guid flightId)
        {
            await _service.DeleteFlightAsync(flightId);
            return NoContent();
        }
    }
}