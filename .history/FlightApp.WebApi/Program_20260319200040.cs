var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthAuthentication(options =>
{
    options.DefaultAutheticationScheme = JwtBearerDefaults.
})
var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
