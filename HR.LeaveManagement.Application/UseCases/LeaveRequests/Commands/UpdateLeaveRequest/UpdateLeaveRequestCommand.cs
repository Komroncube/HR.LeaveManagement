using HR.LeaveManagement.Application.Messaging;
using MediatR;

namespace HR.LeaveManagement.Application.UseCases.LeaveRequests.Commands.UpdateLeaveRequest
{
    public class UpdateLeaveRequestCommand : ICommand<Unit>
    {
        public int Id { get; set; }
        public UpdateLeaveRequestDto? UpdateLeaveRequestDto { get; set; }

        public ChangeLeaveRequestApprovalDto? ChangeLeaveRequestApprovalDto { get; set; }
    }
}
