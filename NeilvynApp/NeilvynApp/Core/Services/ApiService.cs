using Newtonsoft.Json;
using System.Text.Json;

namespace NeilvynApp.Core.Services
{
    class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetAsync(string uri)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(uri);

            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();

           return responseContent;
        }
    }
}
