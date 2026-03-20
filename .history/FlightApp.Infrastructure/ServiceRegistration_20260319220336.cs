namespace FlightApp.Infrastructure
{
    public static IServiceCollections ServiceRegistration(IServiceCollections services)
    {
        services.AddScoped<IBookingReppository, BookingReppository>()
        return services;
    }
}