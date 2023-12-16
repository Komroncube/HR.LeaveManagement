using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistance;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        public CreateLeaveAllocationValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            Include(new LeaveAllocationDtoValidator(leaveTypeRepository));

        }
    }
}
