using HospitalManagementSystem.PatientService.Context;
using HospitalManagementSystem.PatientService.Services.PatientServices;
using HospitalManagementSystem.PatientService.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<PatientContext>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettingsKey"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
