using HR.LeaveManagement.Application.Messaging;
using HR.LeaveManagement.Application.Responses;

namespace HR.LeaveManagement.Application.UseCases.LeaveTypes.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommand : ICommand<BaseCommandResponse>
    {
        public LeaveTypeDto LeaveTypeDto { get; set; }
    }
}
