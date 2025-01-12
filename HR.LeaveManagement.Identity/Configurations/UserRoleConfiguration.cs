using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity.Configurations;
public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
        new IdentityUserRole<string>
        {
            RoleId = "FDB4E31C-20CA-439B-B516-CAAF374A21C4",
            UserId = "C14F0765-A3B9-44B7-A1E2-30606272A28D"
        },
        new IdentityUserRole<string>
        {
            RoleId = "22F13F15-D250-43FD-A2EC-864759C071DC",
            UserId = "A61D8126-E9E6-43B7-B58D-77D5A99DDC42"
        });
    }
}
