using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels;
using WebModels.TaskRequest;

namespace WebClients.services.Tasks
{
    public interface ITaskApiClient
    {
        Task<List<TaskDTO>> GetAllTask(TaskListSearch taskListSearch);
        Task<TaskDTO> GetTaskDetail(string Id);
        Task<bool> CreateTask(TaskCreateRequest request);

    }
}
