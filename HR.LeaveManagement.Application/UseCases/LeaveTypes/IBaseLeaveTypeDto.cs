namespace HR.LeaveManagement.Application.DTOs.LeaveType
{
    public interface IBaseLeaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
