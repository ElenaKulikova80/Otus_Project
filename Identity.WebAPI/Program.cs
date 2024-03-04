using AutoMapper;
using Identity.WebAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Identity.WebAPI.Mapping;
using Identity.WebAPI;
using Identity.BLL.Abstractions;
using Identity.BLL.Services;
using Identity.BLL.DTO.JWT;
using Identity.WebAPI.RabbitMq;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IdentityContext>(x =>
{
  x.UseNpgsql(builder.Configuration.GetConnectionString("identity"), b => b.MigrationsAssembly("Identity.WebAPI"));
});

builder.Services.AddIdentity<ApplicationUser, ApplicationUserRole>()
    .AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddScoped(typeof(IJwtService), typeof(JwtService));
builder.Services.AddScoped(typeof(IRabbitMqProducer), typeof(RabbitMqProducer));


builder.Services.AddSingleton<IMapper>(new Mapper(new MapperConfiguration(cfg =>
{
  cfg.AddProfile<IdentityMapperProfile>();
}
)));

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
  options.AddDefaultPolicy(
            policy =>
            {
              policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
            }));

var jwtOptionsSection = builder.Configuration.GetRequiredSection("JWTSettings");
builder.Services.Configure<JwtModel>(jwtOptionsSection);

builder.Services.AddAuthentication(options =>
{
  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwtOptions =>
{
  var configKey = jwtOptionsSection["SecretKey"];
  var key = Encoding.UTF8.GetBytes(configKey);

  jwtOptions.TokenValidationParameters = new TokenValidationParameters
  {
    ValidIssuer = jwtOptionsSection["Issuer"],
    ValidAudience = jwtOptionsSection["Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(key),
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = false,
    ValidateIssuerSigningKey = true
  };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
