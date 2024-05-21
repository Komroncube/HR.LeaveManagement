using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistance;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(p=> p.RequestComments)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(500);
            Include(new ILeaveRequestDtoValidator(leaveTypeRepository));
        }
    }
}
