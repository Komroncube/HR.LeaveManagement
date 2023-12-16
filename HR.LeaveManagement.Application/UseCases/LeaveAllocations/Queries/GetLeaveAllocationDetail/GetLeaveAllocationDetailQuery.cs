using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Messaging;

namespace HR.LeaveManagement.Application.UseCases.LeaveAllocations.Queries.GetLeaveAllocationDetail
{
    public class GetLeaveAllocationDetailQuery : IQuery<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}
