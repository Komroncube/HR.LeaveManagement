using HR.LeaveManagement.Application.DTOs.Common;
using HR.LeaveManagement.Application.UseCases.LeaveTypes;
using System;

namespace HR.LeaveManagement.Application.UseCases.LeaveRequests.Queries.GetLeaveRequestList
{
    public class LeaveRequestListDto : BaseDto
    {
        public LeaveTypeDto LeaveTypeDto { get; set; }
        public DateTime DateRequested { get; set; }
        public bool? Approved { get; set; }
    }
}
