using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeDtoValidatior : AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeDtoValidatior()
        {
            Include(new LeaveTypeDtoValidator());
        }
    }
}
