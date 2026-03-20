using System.Reflection.Metadata;

namespace FlightApp.Application.Settings;

public class JwtService : IJwtService
{
    private readonly IConfiguration _config;
    public JwtService(IConfiguration config)
    {
        _config = config;
    }

    public string GenerateToken(User user, IList<string> roles)
}
