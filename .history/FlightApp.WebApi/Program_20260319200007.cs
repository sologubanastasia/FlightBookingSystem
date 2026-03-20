var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthAuthentication(options =>)
var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
