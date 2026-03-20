var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthAuthentication(options =>
{
    options.DefaultAutheticationScheme = JwtBearerDefaults.AuthenticationScheme;
    op
})
var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
