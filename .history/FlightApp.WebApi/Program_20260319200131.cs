var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthAuthentication(options =>
{
    options.DefaultAutheticationScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallangeA
})
var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
