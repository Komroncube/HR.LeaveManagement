using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistance.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagementDbContext _dbContext;
        public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus)
        {
            leaveRequest.Approved = ApprovalStatus;
            _dbContext.Entry(leaveRequest).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<LeaveRequest>> GetAllLeaveRequestsWithDetails()
        {
            var leaveRequests = await _dbContext.LeaveRequests
                .Include(x => x.LeaveType)
                .AsNoTracking()
                .ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _dbContext.LeaveRequests
                .Include(x => x.LeaveType)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            if(leaveRequest is null)
            {
                throw new NotFoundException(nameof(LeaveRequest), id);
            }
            return leaveRequest;
        }
    }
}
