using HR.LeaveManagement.Application.Messaging;
using HR.LeaveManagement.Application.Responses;

namespace HR.LeaveManagement.Application.UseCases.LeaveAllocations.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommand : ICommand<BaseCommandResponse>
    {
        public CreateLeaveAllocationDto LeaveAllocationDto { get; set; }
    }
}
