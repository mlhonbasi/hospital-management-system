using HospitalManagementSystem.AppointmentService.Entitites;
using HospitalManagementSystem.AppointmentService.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HospitalManagementSystem.AppointmentService.Context
{
    public class AppointmentContext(IOptions<DatabaseSettings> databaseSettings) : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(databaseSettings.Value.ConnectionString);
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentDetail> AppointmentDetails { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }  

    }
}
