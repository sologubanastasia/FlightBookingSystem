var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthAuthentication(options =>
{
    options.Defa
})
var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
