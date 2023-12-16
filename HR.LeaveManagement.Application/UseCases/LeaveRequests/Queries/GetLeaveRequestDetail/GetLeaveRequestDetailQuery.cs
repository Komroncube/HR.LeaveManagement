using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Messaging;

namespace HR.LeaveManagement.Application.UseCases.LeaveRequests.Queries.GetLeaveRequestDetail
{
    public class GetLeaveRequestDetailQuery : IQuery<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}
