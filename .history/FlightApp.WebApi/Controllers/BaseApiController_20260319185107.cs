using System.Reflection.Metadata;
using System.Security.Claims;

namespace FlightApp.WebApi.Controllers
{
   public abstract class BaseApiController : ControllerBase
    {
        protected Guid CurrentUserId
        {
            get
            {
                var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                return string.IsNullOrEmpty(userIdClaim) ? Guid.Empty : Guid.Parse(userIdClaim);
            }
        }

        protected bool IsAdmin 
    }
}