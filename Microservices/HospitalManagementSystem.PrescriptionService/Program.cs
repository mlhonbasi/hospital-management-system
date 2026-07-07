using HospitalManagementSystem.PrescriptionService.Context;
using HospitalManagementSystem.PrescriptionService.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("PostgreConnection");

builder.Services.AddDbContext<PrescriptionContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();

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
