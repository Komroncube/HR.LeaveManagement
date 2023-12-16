using HR.LeaveManagement.Application.Messaging;
using MediatR;

namespace HR.LeaveManagement.Application.UseCases.LeaveTypes.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommand : ICommand<Unit>
    {
        public int Id { get; set; }
    }
}
