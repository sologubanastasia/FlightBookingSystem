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
    public class AuthController : BaseApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            
            if (result == null || string.IsNullOrEmpty(result.Token))
            {
                return BadRequest("Invalid credentials");
            }

            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto);
            return Ok(result);
        }
    }
}