using MeowTasksBackend.IOC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.DependenciesInjection(builder.Configuration);

var key = builder.Configuration.GetSection("JWTSettings:key").Value;
var keyBytes = Encoding.ASCII.GetBytes(key);

builder.Services.AddAuthentication(conf =>
{
  conf.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  conf.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(conf =>
{
  conf.RequireHttpsMetadata = false;
  conf.SaveToken = true;
  conf.TokenValidationParameters = new TokenValidationParameters
  {
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
    ValidateIssuer = false,
    ValidateAudience = false,
    ValidateLifetime = true,
    ClockSkew = TimeSpan.Zero
  };
});

builder.Services.AddCors(opt =>
{
  opt.AddPolicy("dev", builder => {
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
    builder.AllowAnyOrigin();
  });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors("dev");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
