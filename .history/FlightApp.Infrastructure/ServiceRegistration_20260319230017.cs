namespace FlightApp.Infrastructure
{
    public static IServiceCollections ServiceRegistration(IServiceCollections services)
    {
        services.AddScoped<IBookingReppository, BookingReppository>();
        services.AddScoped<IFlightReppository, FlightReppository>();
        services.AddScoped<ISeatReppository, SeatReppository>();
        services.AddAutoMapper(typeof(MappingProfile));
        return services;
    }
}