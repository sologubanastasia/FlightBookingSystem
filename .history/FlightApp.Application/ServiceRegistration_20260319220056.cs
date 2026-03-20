namespace FlightApp.Application;

public static class ServiceRegistration 
{
    public static IServiceCollection ServiceRegistration(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService
        services.AddScoped<IJwtService, JwtService>();
        return services;
    }
}
