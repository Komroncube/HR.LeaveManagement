using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HR.LeaveManagement.Persistance.Configurations.Entites;
public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
{
    public void Configure(EntityTypeBuilder<LeaveRequest> builder)
    {
        builder.Property(p => p.StartDate).IsRequired();
        builder.Property(p => p.EndDate).IsRequired();
        builder.Property(p => p.DateRequested).IsRequired().HasDefaultValue(DateTime.Now);
        builder.Property(p => p.RequestComments).HasMaxLength(500);
        builder.Property(p => p.DateActioned).IsRequired(false);
        builder.Property(p => p.Approved).IsRequired(false);
        builder.Property(p => p.Cancelled).IsRequired();
        builder.HasOne(p => p.LeaveType).WithMany().HasForeignKey(p => p.LeaveTypeId);

    }
}
