using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Messaging;
using System.Collections.Generic;

namespace HR.LeaveManagement.Application.UseCases.LeaveTypes.Queries.GetLeaveTypeList
{
    public class GetLeaveTypeListQuery : IQuery<List<LeaveTypeDto>>
    {
    }
}
