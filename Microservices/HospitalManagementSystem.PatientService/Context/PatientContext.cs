using HospitalManagementSystem.PatientService.Entities;
using HospitalManagementSystem.PatientService.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HospitalManagementSystem.PatientService.Context
{
    public class PatientContext(IOptions<DatabaseSettings> databaseSettings) : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(databaseSettings.Value.ConnectionString);
        }
        public DbSet<Patient> Patients { get; set; }

    }
}
