using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebModels.Enums;

namespace WebModels
{
    public class TaskCreateRequest
    {
        public Guid Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Name { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}
