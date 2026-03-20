using Microsoft.Extensions.DependencyInjection;
using FlightApp.Domain.Interfaces;
using FlightApp.Infrastructure.Repositories;

namespace FlightApp.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IFlightRepository, FlightRepository>();
        services.AddScoped<ISeatRepository, SeatRepository>();

        return services;
    }
}