using System;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest
{
    public interface IBaseLeaveRequestDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
    }
}
