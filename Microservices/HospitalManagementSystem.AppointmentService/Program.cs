using HospitalManagementSystem.AppointmentService.Context;
using HospitalManagementSystem.AppointmentService.Services;
using HospitalManagementSystem.AppointmentService.Settings;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettingsKey"));
builder.Services.AddSingleton<IDatabaseSettings>(sp =>
sp.GetRequiredService<IOptions<IDatabaseSettings>>().Value);

builder.Services.AddDbContext<AppointmentContext>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
