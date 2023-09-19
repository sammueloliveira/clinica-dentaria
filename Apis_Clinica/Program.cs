using Apis_Clinica.Models;
using Apis_Clinica.Models.Mapping;
using HelpConfig.Startup;
using Infra.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddDbContext<Contexto>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

HelpStartup.ConfigureScoped(builder.Services);

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Minha API", Version = "v1" });

    // JWT Configuration for Swagger UI
    var jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>();
    var securityScheme = new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        Reference = new Microsoft.OpenApi.Models.OpenApiReference
        {
            Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securityScheme);
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        { securityScheme, Array.Empty<string>() }
    });
});

builder.Services.AddDbContext<Contexto>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 3;
})
    .AddEntityFrameworkStores<Contexto>()
    .AddDefaultTokenProviders();

// Jwt
var jwtConfig = builder.Configuration.GetSection("JwtConfig");
builder.Services.Configure<JwtConfig>(jwtConfig);

var jwt = jwtConfig.Get<JwtConfig>();
var key = Encoding.ASCII.GetBytes(jwt.Secret);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwt.Issuer,
        ValidAudience = jwt.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(key),
    };
});


var app = builder.Build();

var urlCliente1 = "https://dominiocliente.com.br";
app.UseCors(b => b.WithOrigins(urlCliente1));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
