var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthAuthentication
var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
