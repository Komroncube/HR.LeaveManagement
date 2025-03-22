using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Models.Identity;
using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity.Services;

class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> userManager;
public UserService(UserManager<ApplicationUser> userManager)
    {
        this.userManager = userManager;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        var users = await userManager.GetUsersInRoleAsync("User");
        return users.Select(u => new User { 
            Id = u.Id,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Email = u.Email 
        }).ToList();
    }
}
