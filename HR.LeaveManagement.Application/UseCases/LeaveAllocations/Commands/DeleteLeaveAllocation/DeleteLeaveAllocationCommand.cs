using HR.LeaveManagement.Application.Messaging;
using MediatR;

namespace HR.LeaveManagement.Application.UseCases.LeaveAllocations.Commands.DeleteLeaveAllocation
{
    public class DeleteLeaveAllocationCommand : ICommand<Unit>
    {
        public int Id { get; set; }
    }
}
