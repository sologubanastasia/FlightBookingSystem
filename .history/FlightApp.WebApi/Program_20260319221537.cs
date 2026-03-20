var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication;
// builder.Services.AddFluentValidationAutoValidation();
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

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "InternHub API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Введіть токен у форматі: Bearer {your_token}",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

app.UseMiddleware<ExceptionHandlingMiddleware>(); // Має бути першим

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "InternHub API v1");
        c.RoutePrefix = string.Empty;  
    });
}

var app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var env = services.GetRequiredService<IHostEnvironment>();
    if (!env.IsEnvironment("Testing")) 
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
        await RoleInitializer.SeedRolesAsync(roleManager);
    }
}

app.MapControllers();
app.Run();
