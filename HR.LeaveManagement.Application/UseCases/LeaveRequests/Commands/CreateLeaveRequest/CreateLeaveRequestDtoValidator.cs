using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistance;

namespace HR.LeaveManagement.Application.UseCases.LeaveRequests.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(p => p.RequestComments)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(500);
            Include(new ILeaveRequestDtoValidator(leaveTypeRepository));
        }
    }
}
