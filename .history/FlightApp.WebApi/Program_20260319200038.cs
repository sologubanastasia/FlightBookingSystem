var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthAuthentication(options =>
{
    options.DefaultAutheticationScheme = JwtBearerDefault
})
var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
