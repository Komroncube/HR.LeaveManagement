using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistance.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _dbContext;
        public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAllocationsAsync(List<LeaveAllocation> leaveAllocations)
        {
            await _dbContext.AddRangeAsync(leaveAllocations);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> AllocationExistsAsync(string userId, int leaveTypeId, int period)
        {
            return await _dbContext.LeaveAllocations.AnyAsync(x => x.EmployeeId == userId 
                                        && x.LeaveTypeId == leaveTypeId 
                                        && x.Period == period);
        }

        public async Task<List<LeaveAllocation>> GetAllLeaveAllocationsWithDetails()
        {
            var leaveAllocations = await _dbContext.LeaveAllocations
                .Include(x => x.LeaveType)
                .ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await _dbContext.LeaveAllocations
                .Include(x => x.LeaveType)
                .FirstOrDefaultAsync(x=>x.Id == id);
            return leaveAllocation;
        }
    }
}
