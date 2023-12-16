using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Messaging;
using System.Collections.Generic;

namespace HR.LeaveManagement.Application.UseCases.LeaveRequests.Queries.GetLeaveReqeustList
{
    public class GetLeaveRequestListQuery : IQuery<List<LeaveRequestListDto>>
    {
    }
}
