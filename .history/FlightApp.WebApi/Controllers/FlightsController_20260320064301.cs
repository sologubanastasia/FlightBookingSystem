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
            return await _service.GetAllFlightsAsync();
            
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Controllers\FlightsController.cs(23,20): error CS0266: Cannot implicitly convert type 'System.Collections.Generic.IEnumerable<FlightApp.Application.Dto.Flight.FlightDto>' to 'Microsoft.AspNetCore.Mvc.IActionResult'. An explicit conversion exists (are you missing a cast?)
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Controllers\BookingsController.cs(22,33): error CS0103: The name '_service' does not exist in the current context
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Controllers\FlightsController.cs(29,41): error CS1061: 'IFlightService' does not contain a definition for 'GetFlightByIdAsync' and no accessible extension method 'GetFlightByIdAsync' accepting a first argument of type 'IFlightService' could be found (are you missing a using directive or an assembly reference?)
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Controllers\AuthController.cs(20,24): error CS1061: 'AuthResponseDto' does not contain a definition for 'Succeeded' and no accessible extension method 'Succeeded' accepting a first argument of type 'AuthResponseDto' could be found (are you missing a using directive or an assembly reference?)
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Controllers\AuthController.cs(22,24): error CS0103: The name 'BadResult' does not exist in the current context
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Controllers\BookingsController.cs(29,32): error CS0103: The name '_service' does not exist in the current context
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Controllers\BookingsController.cs(36,19): error CS0103: The name '_service' does not exist in the current context
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Controllers\AuthController.cs(30,31): error CS0103: The name '_authService' does not exist in the current context
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Controllers\FlightsController.cs(42,41): error CS1061: 'IFlightService' does not contain a definition for 'CreateFlightAsync' and no accessible extension method 'CreateFlightAsync' accepting a first argument of type 'IFlightService' could be found (are you missing a using directive or an assembly reference?)
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Controllers\FlightsController.cs(43,20): error CS0103: The name 'CreateAtAction' does not exist in the current context
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Controllers\FlightsController.cs(49,28): error CS1061: 'IFlightService' does not contain a definition for 'UpdateFlightAsync' and no accessible extension method 'UpdateFlightAsync' accepting a first argument of type 'IFlightService' could be found (are you missing a using directive or an assembly reference?)
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Controllers\FlightsController.cs(57,28): error CS1061: 'IFlightService' does not contain a definition for 'DeleteFlightAsync' and no accessible extension method 'DeleteFlightAsync' accepting a first argument of type 'IFlightService' could be found (are you missing a using directive or an assembly reference?)
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Program.cs(3,18): error CS1061: 'IServiceCollection' does not contain a definition for 'AddApplication' and no accessible extension method 'AddApplication' accepting a first argument of type 'IServiceCollection' could be found (are you missing a using directive or an assembly reference?)
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Program.cs(3,1): error CS0201: Only assignment, call, increment, decrement, await, and new object expressions can be used as a statement
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Program.cs(5,18): error CS1061: 'IServiceCollection' does not contain a definition for 'AddInfrastructure' and no accessible extension method 'AddInfrastructure' accepting a first argument of type 'IServiceCollection' could be found (are you missing a using directive or an assembly reference?)
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Program.cs(6,18): error CS1061: 'IServiceCollection' does not contain a definition for 'AddControlers' and no accessible extension method 'AddControlers' accepting a first argument of type 'IServiceCollection' could be found (are you missing a using directive or an assembly reference?)
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Program.cs(8,18): error CS1061: 'IServiceCollection' does not contain a definition for 'AddAuthAuthentication' and no accessible extension method 'AddAuthAuthentication' accepting a first argument of type 'IServiceCollection' could be found (are you missing a using directive or an assembly reference?)
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Program.cs(26,18): error CS1061: 'IServiceCollection' does not contain a definition for 'AddSwaggerGen' and no accessible extension method 'AddSwaggerGen' accepting a first argument of type 'IServiceCollection' could be found (are you missing a using directive or an assembly reference?)
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Program.cs(48,1):
 error CS0841: Cannot use local variable 'app' before it is declared
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Program.cs(48,19): error CS0246: The type or namespace name 'ExceptionHandlingMiddleware' could not be found (are you missing a using directive or an assembly reference?)
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Program.cs(50,5):
 error CS0841: Cannot use local variable 'app' before it is declared
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Program.cs(52,5):
 error CS0841: Cannot use local variable 'app' before it is declared
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Program.cs(53,5):
 error CS0841: Cannot use local variable 'app' before it is declared
    D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi\Controllers\BookingsController.cs(11,42): warning CS0169: The field 'BookingController._bookingService' is never used

Build failed with 24 error(s) and 2 warning(s) in 2,6s
PS D:\4course\практика\FlightService\FlightApp\FlightApp.WebApi> 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlightById(Guid flightId)
        {
            var flight = await _service.GetFlightByIdAsync(flightId);
            if(flight == null)
            {
                return NotFound();
            }

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