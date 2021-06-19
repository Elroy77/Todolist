using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebModels.Enums;

namespace WebModels
{
    public class TaskDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public Guid? AssigneeId { get; set; }
        public string AssigneeName { get; set; }

        public DateTime CreateDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}
