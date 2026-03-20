using System.Reflection.Metadata;
using System.Security.Claims;

namespace FlightApp.WebApi.Controllers
{
   [ApiController]
   
   public abstract class BaseApiController : ControllerBase
    {
        protected Guid UserId
        {
            get
            {
                var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                return string.IsNullOrEmpty(userIdClaim) ? Guid.Empty : Guid.Parse(userIdClaim);
            }
        }

        protected bool IsAdmin => User.IsInRole("Admin");
    }
}