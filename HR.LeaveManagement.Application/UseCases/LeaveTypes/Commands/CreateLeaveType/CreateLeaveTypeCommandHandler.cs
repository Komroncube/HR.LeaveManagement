using AutoMapper;
using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Messaging;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UseCases.LeaveTypes.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : ICommandHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateLeaveTypeDto> _validator;
        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            //_validator = validations;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            //validatsiya jarayoni(manimcha shart emas)
            var _validator = new CreateLeaveTypeDtoValidator();
            var validationResult = await _validator.ValidateAsync(request.LeaveTypeDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = "Creation failed";
                response.Errors = validationResult.Errors.Select(err => err.ErrorMessage).ToList();
            }
            else
            {
                var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDto);

                leaveType = await _leaveTypeRepository.AddAsync(leaveType);

                //response
                response.IsSuccess = true;
                response.Message = "Created successfully";
                response.Id = leaveType.Id;
            }

            return response;
        }
    }
}
