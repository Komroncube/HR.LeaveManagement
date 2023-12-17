using AutoMapper;
using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Messaging;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UseCases.LeaveTypes.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : ICommandHandler<UpdateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<LeaveTypeDto> _validator;
        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper, IValidator<LeaveTypeDto> validator)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<BaseCommandResponse> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();


            var validationResult = await _validator.ValidateAsync(request.LeaveTypeDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = "Update failed";
                response.Errors = validationResult.Errors.Select(err => err.ErrorMessage).ToList();
            }
            else
            {
                var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDto);

                leaveType = await _leaveTypeRepository.UpdateAsync(leaveType);

                //response
                response.IsSuccess = true;
                response.Message = "Updated successfully";
                response.Id = leaveType.Id;
            }

            return response;
        }
    }
}
