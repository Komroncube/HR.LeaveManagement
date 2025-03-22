using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Services.Base;
using System.Text;

namespace HR.LeaveManagement.MVC.Services;

public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
{
    public LeaveAllocationService(ICacheStorageService cacheStorageService, IClient client) : base(cacheStorageService, client)
    {
    }

    public async Task<Response<int>> CreateLeaveAllocations(int leaveTypeId)
    {
        try
        {
            var response = new Response<int>();
            CreateLeaveAllocationDto createLeaveAllocationDto = new () { LeaveTypeId = leaveTypeId };

            AddBearerToken();
            var apiResponse = await client.LeaveAllocationsPOSTAsync(createLeaveAllocationDto);
            if (apiResponse.IsSuccess)
            {
                response.IsSuccess = true;
                return response;
            }
            else
            {
                var errors = new StringBuilder();
                foreach (var error in apiResponse.Errors)
                {
                    errors.AppendLine(error);
                }
                response.Message = errors.ToString();
                return response;
            }
        }
        catch(ApiException ex)
        {
            return ConvertApiExceptions<int>(ex);
        }
    }
}
