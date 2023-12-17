using HR.LeaveManagement.Application.Messaging;

namespace HR.LeaveManagement.Application.UseCases.LeaveTypes.Queries.GetLeaveTypeDetail
{
    public class GetLeaveTypeDetailQuery : IQuery<LeaveTypeDto>
    {
        public int Id { get; set; }
    }
}
