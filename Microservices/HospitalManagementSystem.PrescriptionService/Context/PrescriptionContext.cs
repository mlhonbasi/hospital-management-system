using HospitalManagementSystem.PrescriptionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.PrescriptionService.Context
{
    public class PrescriptionContext : DbContext
    {
        public PrescriptionContext(DbContextOptions<PrescriptionContext> options) : base(options)
        {
            
        }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionItem> PrescriptionsItems { get; set; }
    }
}
