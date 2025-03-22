using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Contracts;

public interface ILeaveAllocationService
{
    Task<Response<int>> CreateLeaveAllocations(int leaveTypeId);
}
