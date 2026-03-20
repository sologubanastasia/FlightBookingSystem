namespace FlightApp.WebApi.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IAuthService _service;

        public AuthService(IAuthService service)
        {
            _service = service;
        }

        
    }
}