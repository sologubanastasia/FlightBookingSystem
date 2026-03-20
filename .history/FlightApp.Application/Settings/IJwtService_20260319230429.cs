using FlightApp.Domain.Entities
namespace FlightApp.Application.Settings;

public interface IJwtService
{
    string GenerateToken(User user, IList<string> roles);
}
