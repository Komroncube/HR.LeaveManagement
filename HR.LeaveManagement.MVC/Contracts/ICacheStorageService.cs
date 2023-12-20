namespace HR.LeaveManagement.MVC.Contracts;

public interface ICacheStorageService
{
    void ClearStorage(List<string> keys);
    bool IsExists(string key);
    T GetStorageValue<T>(string key);
    void SetStorageValue<T>(string key, T value);
}
