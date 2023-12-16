namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation
{
    public interface IBaseLeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
