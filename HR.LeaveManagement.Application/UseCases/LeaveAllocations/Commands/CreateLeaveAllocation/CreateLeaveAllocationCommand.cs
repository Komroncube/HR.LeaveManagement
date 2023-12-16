using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Messaging;

namespace HR.LeaveManagement.Application.UseCases.LeaveAllocations.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommand : ICommand<int>
    {
        public CreateLeaveAllocationDto LeaveAllocationDto { get; set; }
    }
}
