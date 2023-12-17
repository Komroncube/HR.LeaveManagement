using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveType;

namespace HR.LeaveManagement.Application.UseCases.LeaveTypes
{
    public class LeaveTypeDtoValidatorBase<T> : AbstractValidator<T> where T : IBaseLeaveTypeDto
    {
        public LeaveTypeDtoValidatorBase()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is requred.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters");
            RuleFor(p => p.DefaultDays)
                .NotEmpty().WithMessage("{PropertyName} is requred.")
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1")
                .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisonValue}");
        }
    }
}
