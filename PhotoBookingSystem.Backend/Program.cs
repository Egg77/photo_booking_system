using photo_booking_system.Services;
using photo_booking_system.Providers;
using photo_booking_system.ActionFilters;
using photo_booking_system.Migrations;
using Microsoft.AspNetCore.Mvc;
using FluentMigrator.Runner;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:8081")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

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
builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
        .AddFluentMigratorCore()
        .ConfigureRunner(c => c.AddSqlServer2012()
        .WithGlobalConnectionString("Server=tcp:photo-booking-server.database.windows.net,1433;Initial Catalog=PhotoBookingDB;Persist Security Info=False;User ID=photo-booking-admin;Password=47ZDUhPGrhLTCHgadZfZ;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
            .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());

var app = builder.Build();

app.MigrateDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
