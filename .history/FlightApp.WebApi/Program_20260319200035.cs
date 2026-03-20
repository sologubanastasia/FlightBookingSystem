var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthAuthentication(options =>
{
    options.DefaultAutheticationScheme = JwtBearer
})
var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
