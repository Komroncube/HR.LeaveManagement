using FluentValidation;

namespace HR.LeaveManagement.Application.UseCases.LeaveTypes.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeDtoValidator : LeaveTypeDtoValidatorBase<LeaveTypeDto>
    {
        public UpdateLeaveTypeDtoValidator()
        {
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }

    }
}
