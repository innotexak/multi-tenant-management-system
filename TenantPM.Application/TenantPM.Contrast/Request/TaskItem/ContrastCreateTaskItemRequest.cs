using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantPM.Domain.Enums;

namespace TenantPM.Contrast.Request.TaskItem
{
    public class ContrastCreateTaskItemRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ProjectId { get; set; }
        public Guid? AssignedTo { get; set; }
        public TaskItemStatus Status { get; set; } = TaskItemStatus.ToDo;
    }
}
