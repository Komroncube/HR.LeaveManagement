using HR.LeaveManagement.Application.DTOs.Common;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest
{
    public class ChangeLeaveReqeustApprovalDto : BaseDto
    {
        public bool? Approval { get; set; }
    }
}
