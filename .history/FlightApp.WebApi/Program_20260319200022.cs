var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthAuthentication(options =>
{
    options.DefaultAuthe
})
var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
