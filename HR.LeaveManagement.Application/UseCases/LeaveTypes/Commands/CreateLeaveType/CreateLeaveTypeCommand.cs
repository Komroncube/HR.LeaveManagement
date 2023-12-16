using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Messaging;

namespace HR.LeaveManagement.Application.UseCases.LeaveTypes.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommand : ICommand<int>
    {
        public CreateLeaveTypeDto LeaveTypeDto { get; set; }
    }
}
