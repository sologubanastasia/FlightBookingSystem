using Microsoft.Extensions.DependencyInjection;
using FlightApp.Domain.Interfaces;
using FlightApp.Infrastructure.Repositories;
using FlightApp.Application; // Переконайся, що MappingProfile тут

namespace FlightApp.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Реєстрація репозиторіїв (виправлено помилку Reppository -> Repository)
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IFlightRepository, FlightRepository>();
        services.AddScoped<ISeatRepository, SeatRepository>();

        return services;
    }
}