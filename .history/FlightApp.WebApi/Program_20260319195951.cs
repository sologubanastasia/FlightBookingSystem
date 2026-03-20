var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuth
var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
