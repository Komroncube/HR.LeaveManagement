using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Messaging;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UseCases.LeaveAllocations.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommandHandler : ICommandHandler<CreateLeaveAllocationCommand, BaseCommandResponse>
    {
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IUserService userService;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper, IUserService userService, ILeaveTypeRepository leaveTypeRepository)
        {
            this.leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            this.userService = userService;
            this.leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            //validation process

            var leaveType = await leaveTypeRepository.GetAsync(request.LeaveAllocationDto.LeaveTypeId);
            var users = await userService.GetAllUsersAsync();
            var period = DateTime.Now.Year;
            var allocations = new List<LeaveAllocation>();
            foreach (var user in users)
            {
                if (await leaveAllocationRepository.AllocationExistsAsync(user.Id, leaveType.Id, period))
                    continue;
                allocations.Add(new LeaveAllocation
                {
                    NumberOfDays = leaveType.DefaultDays,
                    Period = period,
                    EmployeeId = user.Id,
                    LeaveTypeId = leaveType.Id
                });
            }
            await leaveAllocationRepository.AddAllocationsAsync(allocations);
            response.IsSuccess = true;
            response.Message = "Leave allocations created successfully";
            return response;
        }
    }
}
