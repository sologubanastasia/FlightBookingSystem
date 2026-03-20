using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FlightApp.Application.Interfaces;
using FlightApp.Application.Dto.Auth;
using FlightApp.Application.Services;
namespace FlightApp.WebApi.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var result = await _service.RegisterAsync(dto);
            if(!result.Succeeded)
            {
                return BadResult(result);
            }

            return Ok(result);
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
}