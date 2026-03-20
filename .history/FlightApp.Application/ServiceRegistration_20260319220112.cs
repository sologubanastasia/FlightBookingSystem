namespace FlightApp.Application;

public static class ServiceRegistration 
{
    public static IServiceCollection ServiceRegistration(this IServiceCollection services)
    {
        services.AddScoped<IBooking
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtService, JwtService>();
        return services;
    }
}
