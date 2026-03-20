namespace FlightApp.Infrastructure
{
    public static IServiceCollections ServiceRegistration(IServiceCollections services)
    {
        services.AddScoped<IBookingReppository, BookingReppository>();
        services.AddScoped<IFlightReppository, BookingReppository>();
        return services;
    }
}