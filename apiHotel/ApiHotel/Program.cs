using DataAccess.Models;
using Domain.Core.Core;
using Domain.Core.ICore;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICoreAgent, CoreAgent>();
builder.Services.AddTransient<IHotelRepository, HotelRepository>();
builder.Services.AddTransient<IRoomRepository, RoomRepository>();
builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HotelApi")));


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
