using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.DependencyInjetion;
namespace FlightApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollections AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IBookingReppository, BookingReppository>();
            services.AddScoped<IFlightReppository, FlightReppository>();
            services.AddScoped<ISeatReppository, SeatReppository>();
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}    