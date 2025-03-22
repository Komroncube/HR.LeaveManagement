using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;

namespace HR.LeaveManagement.Application.UseCases.LeaveAllocations.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        public CreateLeaveAllocationValidator(ILeaveTypeRepository leaveTypeRepository)
        {
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
