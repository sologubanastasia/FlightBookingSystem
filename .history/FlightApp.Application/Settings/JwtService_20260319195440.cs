using System.Reflection.Metadata;
using System.Security.Claims;

namespace FlightApp.Application.Settings;

public class JwtService : IJwtService
{
    private readonly IConfiguration _config;
    public JwtService(IConfiguration config)
    {
        _config = config;
    }

    public string GenerateToken(User user, IList<string> roles)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NammeIdentifier, user.Id.ToString());
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        foreach( var role in roles)
        {
            Claim.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymetricSecurityKey(Enconding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var cred = new SigningCredentials(key, SecurityAlgoritms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config[""]
        );
    }
}
