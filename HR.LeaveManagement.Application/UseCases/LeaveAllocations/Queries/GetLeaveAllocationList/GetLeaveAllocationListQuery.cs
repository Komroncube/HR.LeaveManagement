using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Messaging;
using System.Collections.Generic;

namespace HR.LeaveManagement.Application.UseCases.LeaveAllocations.Queries.GetLeaveAllocationList
{
    public class GetLeaveAllocationListQuery : IQuery<List<LeaveAllocationDto>>
    {
    }
}
