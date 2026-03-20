using Microsoft.Extensions.DependencyInjection;
using FlightApp.Application.Services;
using FlightApp.Application.Settings;
using FlightApp.Application.Interfaces;
using System.Reflection;
using Add
namespace FlightApp.Application;

public static class ServiceRegistration 
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => 
        {
            cfg.AddMaps(Assembly.GetExecutingAssembly());
        });

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<IFlightService, FlightService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtService, JwtService>();
        return services;
    }
}
