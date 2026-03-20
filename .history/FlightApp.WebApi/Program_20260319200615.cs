var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthAuthentication(options =>
{
    options.DefaultAutheticationScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallangeSheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidationIssuer = true,
        ValidationAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSignngKey = true,
        ValidIssuer = 
    };
});
var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
