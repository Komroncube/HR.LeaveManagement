﻿using HR.LeaveManagement.Application.DTOs.Common;
using HR.LeaveManagement.Application.UseCases.LeaveTypes;
using System;

namespace HR.LeaveManagement.Application.UseCases.LeaveRequests.Queries.GetLeaveRequestDetail
{
    public class LeaveRequestDto : BaseDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; } = default!;
        public DateTime? DateActioned { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
    }
}
