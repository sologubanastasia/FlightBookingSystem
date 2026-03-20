var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthAuthentication(options =>
{
    options.DefaultAutheticationScheme = JwtBearerDefaults.Authenti
})
var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
