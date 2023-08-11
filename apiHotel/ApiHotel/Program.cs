using DataAccess.Models;
using Domain.Core.Core;
using Domain.Core.ICore;
using Microsoft.EntityFrameworkCore;
using Repository.Repository;
using Repository.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRepository<Room>, Repository<Room>>();
builder.Services.AddScoped<IRepository<Hotel>, Repository<Hotel>>();
builder.Services.AddScoped<IRepository<Booking>, Repository<Booking>>();
builder.Services.AddScoped<IRepository<Person>, Repository<Person>>();
builder.Services.AddScoped<IRepository<UserInfo>, Repository<UserInfo>>();
builder.Services.AddScoped<IRepository<HotelUser>, Repository<HotelUser>>();
builder.Services.AddScoped<IRepository<BookingPerson>, Repository<BookingPerson>>();

builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HotelApi")));
builder.Services.AddTransient<ICoreAgent, CoreAgent>();
builder.Services.AddTransient<ICoreTraveler, CoreTraveler>();

var x = AppDomain.CurrentDomain.GetAssemblies();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.Run();
