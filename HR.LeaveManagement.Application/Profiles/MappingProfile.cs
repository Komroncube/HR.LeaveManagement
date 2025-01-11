using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.UseCases.LeaveRequests.Commands.CreateLeaveRequest;
using HR.LeaveManagement.Application.UseCases.LeaveRequests.Commands.UpdateLeaveRequest;
using HR.LeaveManagement.Application.UseCases.LeaveRequests.Queries.GetLeaveRequestDetail;
using HR.LeaveManagement.Application.UseCases.LeaveRequests.Queries.GetLeaveRequestList;
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



            // LeaveRequest
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>()
                .ForPath(dest => dest.LeaveTypeDto.Name, opt => opt.MapFrom(src => src.LeaveType.Name))
                .ForPath(dest => dest.LeaveTypeDto.DefaultDays, opt => opt.MapFrom(src => src.LeaveType.DefaultDays))
                .ForPath(dest => dest.LeaveTypeDto.Id, opt => opt.MapFrom(src => src.LeaveType.Id));



            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
        }
    }
}
