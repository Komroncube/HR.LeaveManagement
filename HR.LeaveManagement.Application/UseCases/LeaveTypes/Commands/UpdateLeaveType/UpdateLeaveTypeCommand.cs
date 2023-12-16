using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Messaging;
using MediatR;

namespace HR.LeaveManagement.Application.UseCases.LeaveTypes.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommand : ICommand<Unit>
    {
        public LeaveTypeDto LeaveTypeDto { get; set; }
    }
}
