using AutoMapper;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Services;

public class LeaveTypeService : BaseHttpService, ILeaveTypeService
{
    private readonly IMapper _mapper;
    public LeaveTypeService(ICacheStorageService cacheStorageService, IClient client, IMapper mapper) : base(cacheStorageService, client)
    {
        _mapper = mapper;
    }

    public async Task<Response<int>> CreateLeaveTypeAsync(CreateLeaveTypeVM leaveType)
    {
        try
        {
            var response = new Response<int>();
            CreateLeaveTypeDto leaveTypeDto = _mapper.Map<CreateLeaveTypeDto>(leaveType);
            AddBearerToken();
            BaseCommandResponse apiResponse = await client.LeaveTypesPOSTAsync(leaveTypeDto);
            if (apiResponse.IsSuccess)
            {
                response.Data = apiResponse.Id;
                response.IsSuccess = apiResponse.IsSuccess;
            }
            else
            {
                foreach (string error in apiResponse.Errors)
                {
                    response.ValidationErrors += error + Environment.NewLine;
                }
            }
            return response;
        }
        catch (ApiException ex)
        {    
            return ConvertApiExceptions<int>(ex);
        }
    }

    public async Task<Response<int>> DeleteLeaveTypeAsync(int id)
    {
        try
        {
            AddBearerToken();
            await client.LeaveTypesDELETEAsync(id);
            return new Response<int> { IsSuccess = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<int>(ex);
        }
    }

    public async Task<List<LeaveTypeVM>> GetLeaveTypesAsync()
    {
        AddBearerToken();
        ICollection<LeaveTypeDto> leaveTypes = await client.LeaveTypesAllAsync();
        return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);

    }

    public async Task<LeaveTypeVM> GetLeaveTypeDetailsAsync(int id)
    {
        AddBearerToken();
        LeaveTypeDto leaveType = await client.LeaveTypesGETAsync(id);
        return _mapper.Map<LeaveTypeVM>(leaveType);
    }

    public async Task<Response<int>> UpdateLeaveTypeAsync(LeaveTypeVM leaveType)
    {
        try
        {
            AddBearerToken();
            var leaveTypeDto = _mapper.Map<LeaveTypeDto>(leaveType);
            await client.LeaveTypesPUTAsync(leaveTypeDto);
            return new Response<int> { IsSuccess = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<int>(ex);
        }
    }
}
