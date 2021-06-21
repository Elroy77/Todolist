using System;
using System.Collections.Generic;
using System.Text;
using WebModels.Enums;

namespace WebModels.TaskRequest
{
    public class TaskListSearch
    {
        public Guid? AssigneeId { get; set; }
        public string Name { get; set; }
        public Priority? Priority { get; set; }
    }
}
