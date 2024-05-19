using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Messaging;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UseCases.LeaveRequests.Commands.UpdateLeaveRequest
{
    public class UpdateLeaveRequestCommandHandler : ICommandHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetAsync(request.Id);
            if (request.UpdateLeaveRequestDto != null)
            {
                _mapper.Map(request, leaveRequest);
                await _leaveRequestRepository.UpdateAsync(leaveRequest);

            }
            if (request.ChangeLeaveRequestApprovalDto != null)
            {
                await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDto.Approval);
            }
            return Unit.Value;
        }
    }
}
