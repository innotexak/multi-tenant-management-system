using FluentValidation;
using TenantPM.Application.projects.Command.CreateProjectCommand;

namespace TenantPM.Application.Projects.Command
{
    public class CreateProjectCommandValidator: AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Project name is required")
                .MaximumLength(100)
                .WithMessage("Project name must not exceed 100 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(500)
                .WithMessage("Description must not exceed 500 characters");
        }
    }
}
