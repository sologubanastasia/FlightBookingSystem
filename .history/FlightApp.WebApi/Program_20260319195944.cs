var builder = WebApplication.CreateBuilder(args);

builder.
var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
