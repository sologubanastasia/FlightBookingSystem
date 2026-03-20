using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.DependencyInjetion;
namespace FlightApp.Infrastructure
{
     static class IServiceCollections ServiceRegistration(IServiceCollections services)
    {
        public static IServiceCollections AddInfrastructure(IServiceCollections services)
        {
            services.AddScoped<IBookingReppository, BookingReppository>();
            services.AddScoped<IFlightReppository, FlightReppository>();
            services.AddScoped<ISeatReppository, SeatReppository>();
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}