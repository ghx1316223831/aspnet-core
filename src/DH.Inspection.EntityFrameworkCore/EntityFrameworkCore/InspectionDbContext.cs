using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using DH.Inspection.Authorization.Roles;
using DH.Inspection.Authorization.Users;
using DH.Inspection.MultiTenancy;

namespace DH.Inspection.EntityFrameworkCore
{
    public class InspectionDbContext : AbpZeroDbContext<Tenant, Role, User, InspectionDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<DH.Inspection.Inspections.Inspections> Inspections { get; set; }

        public InspectionDbContext(DbContextOptions<InspectionDbContext> options)
            : base(options)
        {
        }
    }
}
