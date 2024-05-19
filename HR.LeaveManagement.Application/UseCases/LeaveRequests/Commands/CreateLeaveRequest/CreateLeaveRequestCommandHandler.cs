using AutoMapper;
using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Messaging;
using HR.LeaveManagement.Application.Models;
using HR.LeaveManagement.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UseCases.LeaveRequests.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestCommandHandler : ICommandHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateLeaveRequestDto> _validator;

        public CreateLeaveRequestCommandHandler(
            ILeaveRequestRepository leaveRequestRepository, 
            IMapper mapper, 
            IEmailSender emailSender,
            IValidator<CreateLeaveRequestDto> validator)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _emailSender = emailSender;
            _validator = validator;
        }
        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request.LeaveRequestDto, cancellationToken: cancellationToken);
            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);

            leaveRequest = await _leaveRequestRepository.AddAsync(leaveRequest);


            var email = new Email()
            {
                // TODO: Change the email address to the employee's email address
                To = "employee@org.com",
                Body = $"Your leave request for {request.LeaveRequestDto.StartDate: D} to {request.LeaveRequestDto.EndDate} " +
                $"has been submitted successfully",
                Subject = "Leave request Submitted"
            };
            try
            {
                await _emailSender.SendEmailAsync(email);
            }
            catch (Exception ex)
            {
                /// for error cases
            }


            return leaveRequest.Id;
        }
    }
}
