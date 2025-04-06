namespace EdufyAPI.Services.Interfaces
{
    public interface ICacheService
    {
        Task<T> GetDataAsync<T>(string key);
        Task<bool> SetDataAsync<T>(string key, T value, DateTimeOffset expirationTime);
        Task RemoveDataAsync(string key);
    }
}
