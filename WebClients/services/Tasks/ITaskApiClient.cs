using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels;

namespace WebClients.services.Tasks
{
    public interface ITaskApiClient
    {
        Task<List<TaskDTO>> GetAllTask();
    }
}
