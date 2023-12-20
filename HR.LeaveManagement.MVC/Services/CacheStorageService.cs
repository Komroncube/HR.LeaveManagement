using HR.LeaveManagement.MVC.Contracts;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace HR.LeaveManagement.MVC.Services;

public class CacheStorageService : ICacheStorageService
{
    private readonly IDistributedCache _distributedCache;

    public CacheStorageService(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public void ClearStorage(List<string> keys)
    {
        foreach (var key in keys)
        {
            _distributedCache.Remove(key);
        }
    }

    public T GetStorageValue<T>(string key)
    {
        var value = _distributedCache.GetString(key);
        return JsonConvert.DeserializeObject<T>(value);
    }

    public bool IsExists(string key)
    {
        return _distributedCache.Get(key) is not null;
    }

    public void SetStorageValue<T>(string key, T value)
    {
        _distributedCache.SetString(key, JsonConvert.SerializeObject(value));
    }
}
