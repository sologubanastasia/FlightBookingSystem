var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication;
// builder.Servces.AddFluentValidationAutjValidation()
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControlers();

builder.Services.AddAuthAuthentication(options =>
{
    options.DefaultAutheticationScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallangeSheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidationIssuer = true,
        ValidationAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSignngKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymetricSecurityKey(Enconding.UTF.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});
var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
