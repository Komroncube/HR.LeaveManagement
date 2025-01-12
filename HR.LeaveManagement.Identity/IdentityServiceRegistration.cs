using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Models.Identity;
using HR.LeaveManagement.Identity.Models;
using HR.LeaveManagement.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity;
public static class IdentityServiceRegistration
{
    public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddDbContext<LeaveManagementIdentityContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("LeaveManagementIdentityConnection"),
                b => b.MigrationsAssembly(typeof(LeaveManagementIdentityContext).Assembly.FullName));
        });

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<LeaveManagementIdentityContext>()
            .AddDefaultTokenProviders();

        services.AddTransient<IAuthService, AuthService>();

        //Add auth schema
        return services;
    }
}
