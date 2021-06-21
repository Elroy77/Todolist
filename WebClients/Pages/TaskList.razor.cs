using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClients.services.Tasks;
using WebClients.services.Users;
using WebModels;
using WebModels.Enums;

namespace WebClients.Pages
{
    public partial class TaskList
    {
        [Inject] private ITaskApiClient TaskApiClient { get; set; }
        [Inject] private IUserApiClient UserApiClient { get; set; }

        private List<TaskDTO> Tasks;
        private List<AssigneeDTO> Assignees;

        private TaskListSearch TaskListSearch = new TaskListSearch();
        protected override async Task OnInitializedAsync()
        {
            Tasks = await TaskApiClient.GetAllTask();
            Assignees = await UserApiClient.GetAllAssignees();
        }
    }
    public class TaskListSearch
    {
        public Guid AssigneeId { get; set; }
        public string Name { get; set; }
        public Priority Priority { get; set; }
    }    
}
