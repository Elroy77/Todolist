﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebClients.services.Tasks;
using WebModels;

namespace WebClients.Pages
{
    public partial class Todolist
    {
        [Inject] private ITaskApiClient TaskApiClient { get; set; }

        private List<TaskDTO> Tasks;
        protected override async Task OnInitializedAsync()
        {
            Tasks = await TaskApiClient.GetAllTask();
        }
    }
}