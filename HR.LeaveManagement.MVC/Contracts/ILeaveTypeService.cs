using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Contracts;

public interface ILeaveTypeService
{
    Task<List<LeaveTypeVM>> GetLeaveTypesAsync();
    Task<LeaveTypeVM> GetLeaveTypeDetailsAsync(int id);
    Task<Response<int>> CreateLeaveTypeAsync(CreateLeaveTypeVM leaveType);
    Task<Response<int>> UpdateLeaveTypeAsync(LeaveTypeVM leaveType);
    Task<Response<int>> DeleteLeaveTypeAsync(int id);

}
