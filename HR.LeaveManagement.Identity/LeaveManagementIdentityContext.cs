using HR.LeaveManagement.Identity.Configurations;
using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity;
public class LeaveManagementIdentityContext : IdentityDbContext<ApplicationUser>
{
    public LeaveManagementIdentityContext(DbContextOptions<LeaveManagementIdentityContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // For safety considerations, we will add configurations step-by-step
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new RoleConfiguration());
        builder.ApplyConfiguration(new UserRoleConfiguration());
    }

}
