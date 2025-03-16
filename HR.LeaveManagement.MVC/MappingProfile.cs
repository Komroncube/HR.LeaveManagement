using AutoMapper;
using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Models.Auth;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateLeaveTypeDto, CreateLeaveTypeVM>().ReverseMap();
        CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
        CreateMap<RegisterVM, RegistrationRequest>().ReverseMap();
    }
}
