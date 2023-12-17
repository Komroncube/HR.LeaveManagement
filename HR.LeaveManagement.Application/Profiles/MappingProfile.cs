using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.UseCases.LeaveTypes;
using HR.LeaveManagement.Application.UseCases.LeaveTypes.Commands.CreateLeaveType;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //LeaveType
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();




            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
        }
    }
}
