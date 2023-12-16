using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistance;
using System;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class LeaveAllocationDtoValidator : AbstractValidator<IBaseLeaveAllocationDto>
    {
        public LeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(p => p.NumberOfDays)
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1");
            RuleFor(p => p.Period)
                .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}");
            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    return await leaveTypeRepository.ExistsAsync(id);
                })
                .WithMessage("{PropertyName} does not exist.");

        }
    }
}
