using HR.LeaveManagement.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Contracts.Persistance
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
        Task<List<LeaveAllocation>> GetAllLeaveAllocationsWithDetails();
        Task<bool> AllocationExistsAsync(string userId, int leaveTypeId, int period);
        Task AddAllocationsAsync(List<LeaveAllocation> leaveAllocations);
    }
}
