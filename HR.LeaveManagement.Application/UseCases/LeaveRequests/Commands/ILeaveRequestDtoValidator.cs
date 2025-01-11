using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;

namespace HR.LeaveManagement.Application.UseCases.LeaveRequests.Commands
{
    public class ILeaveRequestDtoValidator : AbstractValidator<IBaseLeaveRequestDto>
    {
        public ILeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(p => p.StartDate)
                .LessThan(x => x.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) => await leaveTypeRepository.ExistsAsync(id))
                .WithMessage("{PropertyName} with value {PropertyValue} does not exist.");
        }
    }
}
