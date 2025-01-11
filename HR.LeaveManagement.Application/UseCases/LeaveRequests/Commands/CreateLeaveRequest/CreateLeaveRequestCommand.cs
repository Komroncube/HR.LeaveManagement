using HR.LeaveManagement.Application.Messaging;

namespace HR.LeaveManagement.Application.UseCases.LeaveRequests.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestCommand : ICommand<int>
    {
        public CreateLeaveRequestDto LeaveRequestDto { get; set; }
    }
}
