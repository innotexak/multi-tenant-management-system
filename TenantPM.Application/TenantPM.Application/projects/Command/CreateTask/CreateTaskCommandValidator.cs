using FluentValidation;
using TenantPM.Application.Common.Interfaces;
using TenantPM.Domain.Entities;

namespace TenantPM.Application.projects.Command.CreateTask
{
    public class CreateTaskCommandValidator: AbstractValidator<CreateTaskCommand>
    {
 
        private readonly IAsyncRepository<Project> _projectRepsitory;

        public CreateTaskCommandValidator( IAsyncRepository<Project> projectRepository)
        {
    
            _projectRepsitory = projectRepository;

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
            RuleFor(x => x.ProjectId)
                .NotEmpty().WithMessage("ProjectId is required.")
                .MustAsync(async (projectId, cancellation) =>
                {
                    var project = await _projectRepsitory.ExistsAsync(u => u.Id == projectId);
                    return project != null;
                }).WithMessage("Project does not exist.");
  
           RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Invalid task status specified.");

        }
    }
}