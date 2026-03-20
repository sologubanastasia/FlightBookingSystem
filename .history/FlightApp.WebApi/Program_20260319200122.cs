var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthAuthentication(options =>
{
    options.DefaultAutheticationScheme = JwtBearerDefaults.AuthenticationScheme;
    options.Default
})
var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
