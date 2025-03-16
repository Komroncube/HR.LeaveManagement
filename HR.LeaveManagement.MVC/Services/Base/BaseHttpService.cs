using HR.LeaveManagement.MVC.Contracts;

namespace HR.LeaveManagement.MVC.Services.Base;

public class BaseHttpService
{
    protected readonly ICacheStorageService _cacheStorageService;
    protected IClient _client;

    public BaseHttpService(ICacheStorageService cacheStorageService, IClient client)
    {
        _cacheStorageService = cacheStorageService;
        _client = client;
    }
    protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
    {
        if (ex.StatusCode == 400)
        {
            return new Response<Guid> { Message = "Validation errors occured.", ValidationErrors = ex.Message, IsSuccess = false };
        }
        else if (ex.StatusCode == 404)
        {
            return new Response<Guid> { Message = "The request item could not be found.", IsSuccess = false };
        }
        else
        {
            return new Response<Guid> { Message = "Something went wrong, please try again.", IsSuccess = false };
        }
    }
    protected void AddBearerToken()
    {
        if (_cacheStorageService.IsExists("token"))
        {
            _client.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _cacheStorageService.GetStorageValue<string>("token"));
        }
    }
}
