using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebModels;
using WebModels.TaskRequest;

namespace WebClients.services.Tasks
{
    public class TaskApiClient : ITaskApiClient
    {
        public HttpClient _httpClient;

        public TaskApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TaskDTO>> GetAllTask(TaskListSearch taskListSearch)
        {
            string url = $"/api/tasks?name={taskListSearch.Name}&assigneeid={taskListSearch.AssigneeId}&priority={taskListSearch.Priority}";
            var result = await _httpClient.GetFromJsonAsync<List<TaskDTO>>(url);
                return result;
        }

        public async Task<bool> CreateTask(TaskCreateRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/tasks",request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateTask(Guid Id, TaskUpdateRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/tasks/{Id}", request);
            return result.IsSuccessStatusCode;
        }
        public async Task<TaskDTO> GetTaskDetail(string Id)
        {
            var result = await _httpClient.GetFromJsonAsync<TaskDTO>($"/api/tasks/{Id}");
            return result;
        }
    }
}
