var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthAuthentication(options =>
{
    options.DefaultAutheticationScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallange
})
var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
