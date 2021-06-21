using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels;
using System.Net.Http;
using System.Net.Http.Json;

namespace WebClients.services.Users
{
    public class UserApiClient : IUserApiClient
    {
        public HttpClient _httpClient;
        public UserApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<AssigneeDTO>> GetAllAssignees()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AssigneeDTO>>($"/api/users");
            return result;
        }
    }
}
