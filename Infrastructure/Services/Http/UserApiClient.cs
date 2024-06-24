using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Infrastructure.Services.Http
{
    public class UserApiClient
    {
        private readonly HttpClient _httpClient;

        public UserApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GetUserResponse>> GetUsers()
        {
            var response = await _httpClient.GetAsync("api/User/"); 
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<GetUserResponse>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result;
        }
    }
}
