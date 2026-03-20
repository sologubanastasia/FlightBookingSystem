using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.DependencyInjetion;
namespace FlightApp.Infrastructure
{
    public class static IServiceCollections ServiceRegistration(IServiceCollections services)
    {
        static void services.AddScoped<IBookingReppository, BookingReppository>();
        services.AddScoped<IFlightReppository, FlightReppository>();
        services.AddScoped<ISeatReppository, SeatReppository>();
        services.AddAutoMapper(typeof(MappingProfile));
        return services;
    }
}