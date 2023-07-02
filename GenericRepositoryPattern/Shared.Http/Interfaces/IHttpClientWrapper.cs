namespace Shared.Http.Interfaces
{
    public interface IHttpClientWrapper<T>: IDisposable where T : class, new()
    {
        Task<T> GetAsync(string controller, List<string> parameters);
        Task<bool> Post(string controller, string endpoint, T model);  
    }
}
