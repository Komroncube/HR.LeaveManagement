using HR.LeaveManagement.Application.Messaging;
using HR.LeaveManagement.Application.Responses;

namespace HR.LeaveManagement.Application.UseCases.LeaveTypes.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommand : ICommand<BaseCommandResponse>
    {
        public CreateLeaveTypeDto LeaveTypeDto { get; set; }
    }
}
