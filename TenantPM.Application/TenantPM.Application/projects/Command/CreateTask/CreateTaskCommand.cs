using MediatR;
using TenantPM.Domain.Enums;


namespace TenantPM.Application.projects.Command.CreateTask
{
    public class CreateTaskCommand: IRequest<CreateTaskCommandResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ProjectId { get; set; }
        public Guid? AssignedTo { get; set; }
        public TaskItemStatus Status { get; set; } = TaskItemStatus.ToDo;
    }
}
