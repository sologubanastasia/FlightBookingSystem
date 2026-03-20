using Microsoft.Extensions.
namespace FlightApp.Application;

public static class ServiceRegistration 
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<IFlightService, FlightService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtService, JwtService>();
        return services;
    }
}
