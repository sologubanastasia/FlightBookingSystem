var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthAuthentication(options =>
{
    options.DefaultAuthetication
})
var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
