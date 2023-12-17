using HR.LeaveManagement.Application.DTOs.LeaveType;

namespace HR.LeaveManagement.Application.UseCases.LeaveTypes.Commands.CreateLeaveType
{
    public class CreateLeaveTypeDto : IBaseLeaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
