using photo_booking_system.Services;
using photo_booking_system.Providers;
using photo_booking_system.ActionFilters;
using photo_booking_system.Migrations;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.Configure<ApiBehaviorOptions>(options
    => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddSingleton<ISQLConnectionProvider, SQLConnectionProvider>();
builder.Services.AddSingleton<IDatabase, Database>();

var app = builder.Build();

app.MigrateDatabase();

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
