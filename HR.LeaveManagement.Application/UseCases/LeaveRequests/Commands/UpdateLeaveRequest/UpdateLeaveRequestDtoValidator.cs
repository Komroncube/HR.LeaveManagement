using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;

namespace HR.LeaveManagement.Application.UseCases.LeaveRequests.Commands.UpdateLeaveRequest
{
    public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
    {
        public UpdateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(p => p.Id)
                .NotNull()
                .WithMessage("{PropertyName} must be present");
            RuleFor(p => p.RequestComments)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .MaximumLength(500);
            RuleFor(p => p.Cancelled).NotNull().WithMessage("{PropertyName} is required");
            Include(new ILeaveRequestDtoValidator(leaveTypeRepository));
        }
    }
}
