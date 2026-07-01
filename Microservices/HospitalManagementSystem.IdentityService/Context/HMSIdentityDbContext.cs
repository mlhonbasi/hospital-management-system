using HospitalManagementSystem.IdentityService.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.IdentityService.Context
{
    public class HMSIdentityDbContext : IdentityDbContext<AppUser>
    {
        public HMSIdentityDbContext(DbContextOptions<HMSIdentityDbContext> options) : base(options)
        {
        }
    }
}
