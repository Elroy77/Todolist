using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebModels.Enums;

namespace WebModels.TaskRequest
{
    public class TaskCreateRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(250)]
        [Required]
        public string Name { get; set; }

        [Required]
        public Priority Priority { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
