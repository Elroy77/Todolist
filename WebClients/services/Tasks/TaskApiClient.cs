using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebModels;

namespace WebClients.services.Tasks
{
    public class TaskApiClient : ITaskApiClient
    {
        public HttpClient _httpClient;

        public TaskApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TaskDTO>> GetAllTask()
        {
            var result = await _httpClient.GetFromJsonAsync<List<TaskDTO>>("/api/tasks");
                return result;
        }
    }
}
