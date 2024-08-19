namespace NeilvynApp.Core.Services
{
    public interface IApiService
    {
        Task<string> GetAsync(string uri);
    }
}
