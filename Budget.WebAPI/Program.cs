using AutoMapper;
using Budget.WebAPI.Mappers;
using Budget.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Budget.WebAPI.Mapping;
using Budget.DAL.Abstractions;
using Budget.DAL.Repositories.EF;
using Budget.WebAPI.RabbitMq;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<RabbitMqConsumer>();

builder.Services.AddDbContext<DataContext>(x =>
{
  x.UseNpgsql(builder.Configuration.GetConnectionString("db"));
});

builder.Services.AddScoped(typeof(DbContext), typeof(DataContext));
builder.Services.AddScoped(typeof(IRepository<>), typeof(BasicRepository<>));
//builder.Services.AddScoped(typeof(IRabbitMqConsumer), typeof(RabbitMqConsumer));


builder.Services.AddSingleton<IMapper>(new Mapper(new MapperConfiguration(cfg =>
{
  cfg.AddProfile<CategoryMapperProfile>();
  cfg.AddProfile<IncomeMapperProfile>();
  cfg.AddProfile<ExpenseMappingProfile>();
}
)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
