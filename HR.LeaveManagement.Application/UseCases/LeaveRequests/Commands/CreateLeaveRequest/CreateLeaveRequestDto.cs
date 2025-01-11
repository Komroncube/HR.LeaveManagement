using System;

namespace HR.LeaveManagement.Application.UseCases.LeaveRequests.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestDto : IBaseLeaveRequestDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public string RequestComments { get; set; } = default!;
    }
}
