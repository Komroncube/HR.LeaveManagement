using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Persistance.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
