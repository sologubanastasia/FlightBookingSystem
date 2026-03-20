using Microsoft.AspNetCore.Mvc;
namespace FlightApp.WebApi.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IAuthService _service;

        public AuthService(IAuthService service)
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

        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await _authService.LoginAsync(dto);
            if(token == null)
                return Unauthorized("Invalid credentials");

            return Ok(new {Token = token});    
        }
    }
}