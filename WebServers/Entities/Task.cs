using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebModels.Enums;

namespace WebServers.Entities
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Name { get; set; }
        public Guid? AssigeeId { get; set; }

        [ForeignKey("AssigeeId")]
        public User Assigee { get; set; }
        public DateTime CreateDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}
